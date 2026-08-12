using System.Reflection;
using JetBrains.Annotations;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;

namespace RatshotOfUnusualSize;

[UsedImplicitly, Injectable(TypePriority = OnLoadOrder.TraderRegistration - 1)]
public class RatshotOfUnusualSize(WTTServerCommonLib.WTTServerCommonLib wttServerCommonLib) : IOnLoad
{
    public async Task OnLoadAsync(CancellationToken ct)
    {
        var assembly = Assembly.GetExecutingAssembly();
        await wttServerCommonLib.CustomAssortSchemeService.CreateCustomAssortSchemes(assembly);
        await wttServerCommonLib.CustomItemServiceExtended.CreateCustomItems(assembly);
    }
}