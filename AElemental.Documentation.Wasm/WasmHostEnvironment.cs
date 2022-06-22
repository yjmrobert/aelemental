using System;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace AElemental.Documentation.Wasm;

public class WasmHostEnvironment : IHostEnvironment
{
    public string EnvironmentName
    {
        get => "WASM";
        set => throw new NotImplementedException();
    }

    public string ApplicationName
    {
        get => "AElementalDemo";
        set => throw new NotImplementedException();
    }

    public string ContentRootPath
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }

    public IFileProvider ContentRootFileProvider
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }
}