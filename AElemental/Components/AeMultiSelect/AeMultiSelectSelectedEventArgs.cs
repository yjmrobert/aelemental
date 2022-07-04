using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace AElemental.Components;

public class AeMultiSelectSelectedEventArgs : EventArgs
{
    public List<string>? Value { get; set; }
}