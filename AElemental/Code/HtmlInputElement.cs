/**
 * Copyright 2020 Apption Corporation
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Timers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace AElemental.Code;

public class HtmlInputElement : HtmlElement
{
    protected string _inputValue = "";

    protected KeyboardEventArgs _lastKey;
    protected Timer inputTimer;

    [Parameter] public string Placeholder { get; set; }

    [Parameter] public EventCallback<string> OnInputChange { get; set; }

    [Parameter] public int EventTimer { get; set; } = 500;

    [Parameter] public string DefaultValue { get; set; }

    [Parameter] public Action<string, KeyboardEventArgs> OnInputChangeWithLastKey { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        inputTimer = new Timer(EventTimer);
        inputTimer.Elapsed += OnTimerFire;
        inputTimer.AutoReset = false;
        _inputValue = DefaultValue;
    }

    protected void HandleKeyUp(KeyboardEventArgs e)
    {
        inputTimer.Stop();
        _lastKey = e;
        inputTimer.Start();
    }

    protected void OnTimerFire(object source, ElapsedEventArgs e)
    {
        InvokeAsync(async () =>
        {
            await OnInputChange.InvokeAsync(_inputValue);
            OnInputChangeWithLastKey?.Invoke(_inputValue, _lastKey);
        });
    }
}