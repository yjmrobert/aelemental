using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AElemental.Services;

public class ExcelTextContentParser : IExcelContentParser
{
    public string ValidMimeType { get; } = "text/plain";

    public Task<IList<string[]>> GetRows(string input)
    {
        return Task.FromResult<IList<string[]>>(input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).Select(x =>
            x.Split("\t").Select(y => y ?? string.Empty).ToArray()
        ).ToList());
    }
}