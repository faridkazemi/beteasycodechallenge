using dotnet_code_challenge.Model;
using System.Collections.Generic;

namespace dotnet_code_challenge.Manager
{
    public interface IRaceDataManager
    {
        List<HorseCommonModel> GetHorsesFromAllSources();
    }
}
