// @ts-ignore
Blazor.registerCustomEventType('aemultiselectselected', {
    browserEventName: 'bx-multi-select-selected',
    createEventArgs: (event: any) => {
        return {
            value: event.currentTarget.__value
        };
    }
});