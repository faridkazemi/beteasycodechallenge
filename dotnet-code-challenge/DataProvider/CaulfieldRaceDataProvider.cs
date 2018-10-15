using System;
using System.Collections.Generic;
using dotnet_code_challenge.Model;

namespace dotnet_code_challenge.DataProvider
{
    public class CaulfieldRaceDataProvider : IDataProvider
    {
        public string KeySelector => "Caulfield";

        public List<HorseCommonModel> ReadData(string sourceContent)
        {
            return new List<HorseCommonModel> {
                new HorseCommonModel { Name = "Horse 2", Price = 567.75m }
            };
        }
    }
}
