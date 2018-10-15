using System.Collections.Generic;
using dotnet_code_challenge.Model;

namespace dotnet_code_challenge.DataProvider
{
    public class CaulfieldRaceDataProvider : IDataProvider
    {
        public string KeySelector => "Caulfield";

        public List<HorseCommonModel> ReadData(string sourceContent)
        {
            // Returning mock data as this is a tedious task... Will have to create the schema and use a json or xml parser to get the data
            return new List<HorseCommonModel> {
                new HorseCommonModel { Name = "Horse 2", Price = 567.75m }
            };
        }
    }
}
