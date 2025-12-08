using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Spt.Mod;

namespace RatshotOfUnusualSize;

public record AmmoBox_RatshotOfUnusualSize_10RND : NewItemFromCloneDetails
{
    public override MongoId? ItemTplToClone { get; set; } = ItemTpl.AMMOBOX_127X55_PS12_10RND;

    public override TemplateItemProperties? OverrideProperties { get; set; } = new()
    {
        Prefab = new Prefab
        {
            Path = "ammobox_50bmg_ratshot.bundle",
            Rcid = ""
        },
        BackgroundColor = "violet",
        CanSellOnRagfair = false,
        AmmoCaliber = "Caliber127x99",
        StackSlots =
        [
            new StackSlot
            {
                Id = "693641c2d09da95973053055",
                MaxCount = 10,
                Name = "cartridges",
                Parent = "69364043d09da95973053054",
                Properties = new StackSlotProperties
                {
                    Filters = 
                    [
                        new SlotFilter
                        {
                            Filter = 
                            [
                                "69363bc9d09da95973053053"
                            ]
                        }
                    ]
                },
                Prototype = "5748538b2459770af276a261"
            }
        ]
    };

    public override string? ParentId { get; set; } = "543be5cb4bdc2deb348b4568";
    public override string? NewId { get; set; } = "69364043d09da95973053054";
    public override double? FleaPriceRoubles { get; set; } = 0;
    public override double? HandbookPriceRoubles { get; set; } = 1000;
    public override string? HandbookParentId { get; set; } = "5b47574386f77428ca22b33c";
    public override Dictionary<string, LocaleDetails>? Locales { get; set; } = new()
    {
        {
            "en", new LocaleDetails
            {
                Name = ".50 BMG Ratshot ammo pack (10 pcs)",
                ShortName = "Ratshot",
                Description = "A box of .50 BMG Ratshot cartridges, 10 pieces."
            }
        }
    };
}