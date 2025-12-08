using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Spt.Mod;

namespace RatshotOfUnusualSize;

public record Ammo_RatshotOfUnusualSize : NewItemFromCloneDetails
{
    public override MongoId? ItemTplToClone { get; set; } = ItemTpl.AMMO_127X99_M21;

    public override TemplateItemProperties? OverrideProperties { get; set; } = new()
    {
        Prefab = new Prefab
        {
            Path = "ammo_50bmg_ratshot.bundle",
            Rcid = ""
        },
        Damage = 0.5,
        ProjectileCount = 1000,
        BuckshotBullets = 1000,
        Weight = 115,
        AmmoAccr = 0,
        AmmoType = "buckshot",
        RicochetChance = 0,
        AmmoTooltipClass = "SoftTargets",
        ArmorDamage = 15,
        BallisticCoeficient = 0.025,
        BulletDiameterMillimeters = 0.0,
        BulletMassGram = 0.00,
        CanSellOnRagfair = false,
        PenetrationPower = 1,
        PenetrationPowerDeviation = 1,
        StaminaBurnPerDamage = 0.1
    };

    public override string? ParentId { get; set; } = "5485a8684bdc2da71d8b4567";
    public override string? NewId { get; set; } = "69363bc9d09da95973053053";
    public override double? FleaPriceRoubles { get; set; } = 4200;
    public override double? HandbookPriceRoubles { get; set; } = 690;
    public override string? HandbookParentId { get; set; } = "5b47574386f77428ca22b33b";

    public override Dictionary<string, LocaleDetails>? Locales { get; set; } = new()
    {
        {
            "en", new LocaleDetails
            {
                Name = ".50 BMG Ratshot",
                ShortName = "Ratshot",
                Description = "A .50 BMG (12.7x99mm NATO) Ratshot cartridge, developed in Florin and adopted in [ERR_DATE_NULL] for the Barrett M107, primarily designed for the eradication of rodents of unusual size. The cartridge has gained a significant alternate use as an anti-personnel cartridge as its count of one thousand lead pellets deliver a devastating blow to multiple combatants if given enough time to expand."
            }
        }
    };
}