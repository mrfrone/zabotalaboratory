using System.Collections.Generic;
using System.Threading.Tasks;
using zabotalaboratory.Analyses.Datamodel.Analyses;
using zabotalaboratory.Common.Result;

namespace zabotalaboratory.Analyses.Services.Analyses
{
    public interface IAnalysesService
    {
        Task<ZabotaResult<IEnumerable<ZabotaAnalysesTypes>>> GetAnalysesWithTests();

        Task<ZabotaResult<ZabotaAnalysesTypes>> GetAnalysesTypeById(int id);
    }
}
