using System.Collections.Generic;
using System.Threading.Tasks;
using zabotalaboratory.Analyses.Datamodel.LaboratoryAnalyses;
using zabotalaboratory.Common.Result;

namespace zabotalaboratory.Analyses.Services.LaboratoryAnalyses
{
    public interface ILaboratoryAnalysesService
    {
        Task<ZabotaResult<IEnumerable<ZabotaLaboratoryAnalyses>>> GetLaboratoryAnalyses();
        Task<ZabotaResult<ZabotaLaboratoryAnalyses>> GetLaboratoryAnalyseById(int id);
    }
}
