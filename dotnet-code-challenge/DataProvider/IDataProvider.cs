using dotnet_code_challenge.Model;
using System.Collections.Generic;

namespace dotnet_code_challenge.DataProvider
{
    public interface IDataProvider
    {
        string KeySelector { get; }
        List<HorseCommonModel> ReadData(string sourceContent);
    }
}
