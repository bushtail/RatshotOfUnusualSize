using JetBrains.Annotations;
using SPTarkov.Server.Core.Models.Spt.Mod;
using Range = SemanticVersioning.Range;
using Version = SemanticVersioning.Version;

namespace RatshotOfUnusualSize;

[UsedImplicitly]
public record ModMetadata : AbstractModMetadata
{
    public override string ModGuid { get; init; } = "ca.bushtail.ratshotofunusualsize";
    public override string Name { get; init; } = "RatshotOfUnusualSize";
    public override string Author { get; init; } = "bushtail";
    public override List<string>? Contributors { get; init; } = [ "Dar'Zhar", "EpicRangeTime" ];
    public override Version Version { get; init; } = new(typeof(ModMetadata).Assembly.GetName().Version?.ToString(3));
    public override Range SptVersion { get; init; } = new("~4.0.0");
    public override List<string>? Incompatibilities { get; init; }
    public override Dictionary<string, Range>? ModDependencies { get; init; } = new()
    {
        { "com.wtt.commonlib", new Range("~2.0.0") }
    };
    public override string? Url { get; init; }
    public override bool? IsBundleMod { get; init; } = true;
    public override string License { get; init; } = "MIT";
}