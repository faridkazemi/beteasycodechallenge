using dotnet_code_challenge.DataProvider;
using dotnet_code_challenge.Helper;
using dotnet_code_challenge.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace dotnet_code_challenge.Manager
{
    public class RaceDataManager : IRaceDataManager
    {
        private readonly ILogger logger;

        public RaceDataManager(ILogger logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Gets the all the horses and their prices from the various sources. If a new source is introduced make sure 
        /// to create another DataProvider with correct key
        /// </summary>
        /// <returns>All Horses sorted by price in ascending order</returns>
        public List<HorseCommonModel> GetHorsesFromAllSources()
        {
            try
            {
                var allSources = GetAllSources();
                var allHorses = new List<HorseCommonModel>();

                foreach (var source in allSources)
                {
                    var dataProvider = Bootstraper.serviceProvider.GetServices<IDataProvider>().OfType<IDataProvider>().SingleOrDefault(x => source.Key.Contains(x.KeySelector));
                    if (dataProvider == null)
                    {
                        throw new ApplicationException($"Could not find a DataProvider for {source.Key}");
                    }
                    allHorses.AddRange(dataProvider.ReadData(source.Value));
                }

                // This could be seperated as a seperate concern, that will keep this class simpler and will make this more maintainable 
                allHorses = allHorses.OrderBy(x => x.Price).ToList();

                return allHorses;
            }
            catch (Exception ex)
            {
                // We will need more specific logging and potential failure recovery strategies (retries,...)
                logger.LogError($"Failed to get Horses from sources. Exception:{ex}");
                throw;
            }
        }


        /// <summary>
        /// This should be a Reader set of classes that can read data from different sources, for simplicity we assume all the sources are files in a folder
        /// and their name will always have the key to distinguish the required provider. Again this should be seperated in a different class
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> GetAllSources()
        {
            var result = new Dictionary<string, string>();
            foreach (var item in Directory.GetFiles(AppSettings.SourcePath))
            {
                result.Add(item, File.ReadAllText(item));
            }
            return result;
        }
    }
}
