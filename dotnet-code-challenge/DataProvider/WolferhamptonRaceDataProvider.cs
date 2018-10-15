using dotnet_code_challenge.Model;
using System.Collections.Generic;

namespace dotnet_code_challenge.DataProvider
{
    public class WolferhamptonRaceDataProvider : IDataProvider
    {
        public string KeySelector => "Wolferhampton";

        public List<HorseCommonModel> ReadData(string sourceContent)
        {
            // Returning mock data as this is a tedious task... Will have to create the schema and use a json or xml parser to get the data
            return new List<HorseCommonModel> {
                new HorseCommonModel { Name = "Horse 1", Price = 123.25m }
            };
        }

    }
}
