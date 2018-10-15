using dotnet_code_challenge.Model;
using System;
using System.Collections.Generic;

namespace dotnet_code_challenge.DataProvider
{
    public class WolferhamptonRaceDataProvider : IDataProvider
    {
        public string KeySelector => "Wolferhampton";

        public List<HorseCommonModel> ReadData(string sourceContent)
        {
            return new List<HorseCommonModel> {
                new HorseCommonModel { Name = "Horse 1", Price = 123.25m }
            };
        }

    }
}
