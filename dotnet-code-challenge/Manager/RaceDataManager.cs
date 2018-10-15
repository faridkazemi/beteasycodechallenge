using dotnet_code_challenge.DataProvider;
using dotnet_code_challenge.Helper;
using dotnet_code_challenge.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace dotnet_code_challenge.Manager
{
    public class RaceDataManager : IRaceDataManager
    {
        private readonly ILogger logger;
        private readonly IServiceProvider serviceProvider;
        private readonly ISourceProvider sourceProvider;

        public RaceDataManager(ILogger logger, IServiceProvider serviceProvider, ISourceProvider sourceProvider)
        {
            this.logger = logger;
            this.serviceProvider = serviceProvider;
            this.sourceProvider = sourceProvider;
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
                var allSources = sourceProvider.GetAllSources();
                var allHorses = new List<HorseCommonModel>();

                foreach (var source in allSources)
                {
                    var allDataProviders = serviceProvider.GetService(typeof(IEnumerable<IDataProvider>)) as IEnumerable<IDataProvider>;
                    var dataProvider = allDataProviders.SingleOrDefault(x => source.Key.Contains(x.KeySelector));
                    if (dataProvider == null)
                    {
                        // We'll log an error and even trigger an alarm but will continue to return the valid sources to keep operation running
                        logger.LogError($"Could not find a DataProvider for {source.Key}");
                        continue;
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
    }
}
