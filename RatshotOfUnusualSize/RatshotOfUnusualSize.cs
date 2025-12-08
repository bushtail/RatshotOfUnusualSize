using JetBrains.Annotations;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Enums;
using SPTarkov.Server.Core.Servers;
using SPTarkov.Server.Core.Services.Mod;

namespace RatshotOfUnusualSize;

[UsedImplicitly, Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 1)]
public class RatshotOfUnusualSize(DatabaseServer databaseServer, CustomItemService customItemService) : IOnLoad
{
    private readonly NullReferenceException _nullReferenceException = new();
    public Task OnLoad()
    {
        var itemsDb = databaseServer.GetTables().Templates.Items;
        var traderDb = databaseServer.GetTables().Traders;
        if (!traderDb.TryGetValue(Traders.REF, out var trader) || !itemsDb.TryGetValue(ItemTpl.MARKSMANRIFLE_THEAKGUY_AK50_50_BMG_SNIPER_RIFLE, out var weapon) || !itemsDb.TryGetValue(ItemTpl.MAGAZINE_127X99_M82_10RND, out var magazine)) throw _nullReferenceException;

        var ammo = new Ammo_RatshotOfUnusualSize();
        var ammoBox = new AmmoBox_RatshotOfUnusualSize_10RND();
        
        customItemService.CreateItemFromClone(ammo);
        customItemService.CreateItemFromClone(ammoBox);
        
        if (!itemsDb.TryGetValue(new MongoId(ammo.NewId!), out var newBullet) || !itemsDb.TryGetValue(new MongoId(ammoBox.NewId!), out var newBulletBox)) throw _nullReferenceException;

        var weaponProperties = weapon.Properties;
        if (weaponProperties == null) throw _nullReferenceException;
        
        var chambers = weaponProperties.Chambers;
        if (chambers == null) throw _nullReferenceException;
        foreach (var chamber in chambers)
        {
            var chamberProps = chamber.Properties;
            if (chamberProps == null) continue;
            var filters = chamberProps.Filters;
            if (filters == null) continue;
            foreach (var filter in filters)
            {
                var _filter = filter.Filter;
                _filter?.Add(newBullet.Id);
            }
        }
        
        var magazineProperties = magazine.Properties;
        if (magazineProperties == null) throw _nullReferenceException;
        
        var cartridges = magazineProperties.Cartridges;
        if (cartridges == null) throw _nullReferenceException;
        foreach (var cartridge in cartridges)
        {
            var cartridgeProps = cartridge.Properties;
            if (cartridgeProps == null) continue;
            var filters = cartridgeProps.Filters;
            if (filters == null) continue;
            foreach (var filter in filters)
            {
                var _filter = filter.Filter;
                _filter?.Add(newBullet.Id);
            }
        }

        var assort = trader.Assort;
        var assortItems = assort.Items;
        var assortBarterSchemes = assort.BarterScheme;
        var assortLoyalLevelItems = assort.LoyalLevelItems;
        var newAssortID = new MongoId("693645d70a250a9e1a0e0db0");
        
        assortItems.Add(new Item
        {
            Id = newAssortID,
            Template = newBulletBox.Id,
            ParentId = "hideout",
            SlotId = "hideout",
            Upd = new Upd
            {
                UnlimitedCount = true,
                StackObjectsCount = 9999999,
                BuyRestrictionMax = 69,
                BuyRestrictionCurrent = 0
            }
        });
        
        assortBarterSchemes.Add(newAssortID, [
            [
                new BarterScheme
                {
                    Count = 8,
                    Template = ItemTpl.MONEY_GP_COIN
                }
            ]
        ]);
        
        assortLoyalLevelItems.Add(newAssortID, 2);
        
        return Task.CompletedTask;
    }
}