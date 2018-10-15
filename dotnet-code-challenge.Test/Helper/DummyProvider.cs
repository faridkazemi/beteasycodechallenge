using dotnet_code_challenge.DataProvider;
using dotnet_code_challenge.Model;
using System.Collections.Generic;

namespace dotnet_code_challenge.Test.Helper
{
    public class DummyProvider : IDataProvider
    {
        public string KeySelector => "DummyProvider";

        public List<HorseCommonModel> ReadData(string sourceContent)
        {
            return new List<HorseCommonModel>();
        }
    }
}
