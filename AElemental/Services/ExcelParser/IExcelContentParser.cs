using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AElemental.Services;

public interface IExcelContentParser
{
    string ValidMimeType { get; }

    public bool CanParse(string mimeType)
    {
        return ValidMimeType.Equals(mimeType, StringComparison.InvariantCultureIgnoreCase);
    }

    Task<IList<string[]>> GetRows(string input);
}