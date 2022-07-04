using AElemental.Components;
using Microsoft.AspNetCore.Components;

namespace AElemental.Code;

[EventHandler("onaedropdownselected", typeof(AeDropdownSelectedEventArgs), true, true)]
[EventHandler("onaeselectselected", typeof(AeSelectSelectedEventArgs))]
[EventHandler("onaemultiselectselected", typeof(AeMultiSelectSelectedEventArgs))]
public static class EventHandlers
{
}