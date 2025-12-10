using System.Reflection;
using JetBrains.Annotations;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Common;
using WTTServerCommonLib.Models;

namespace RatshotOfUnusualSize;

[UsedImplicitly, Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 1)]
public class RatshotOfUnusualSize(WTTServerCommonLib.WTTServerCommonLib wttServerCommonLib) : IOnLoad
{
    public async Task OnLoad()
    {
        var assembly = Assembly.GetExecutingAssembly();
        TraderIds.Add("REF", new MongoId("6617beeaa9cfa777ca915b7c"));
        await wttServerCommonLib.CustomAssortSchemeService.CreateCustomAssortSchemes(assembly);
        await wttServerCommonLib.CustomItemServiceExtended.CreateCustomItems(assembly);
    }
}