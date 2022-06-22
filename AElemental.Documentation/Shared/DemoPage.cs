using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace AElemental.Documentation.Shared;

public class DemoPage : ComponentBase
{
    [Inject] private IJSRuntime JSRuntime { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        // await JSRuntime.InvokeVoidAsync("initHighlight");
    }
}