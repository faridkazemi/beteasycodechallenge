using System.Collections.Generic;

namespace dotnet_code_challenge.DataProvider
{
    public interface ISourceProvider
    {
        Dictionary<string, string> GetAllSources();
    }
}