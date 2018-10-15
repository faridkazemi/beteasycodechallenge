using dotnet_code_challenge.Manager;
using System;

namespace dotnet_code_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Bootstraper.SetupAutofac();

            var manager = Bootstraper.serviceProvider.GetService(typeof(IRaceDataManager)) as IRaceDataManager;
            var allHorses = manager.GetHorsesFromAllSources();

            foreach (var horse in allHorses)
            {
                Console.WriteLine(horse.Name);
            }
        }
    }
}
