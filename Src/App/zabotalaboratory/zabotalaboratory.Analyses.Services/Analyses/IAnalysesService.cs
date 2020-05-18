using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using zabotalaboratory.Analyses.Datamodel.LaboratoryAnalyses;
using zabotalaboratory.Common.Result;

namespace zabotalaboratory.Analyses.Services.AnalysesService
{
    public interface IAnalysesService
    {
        Task<ZabotaResult<IEnumerable<ZabotaLaboratoryAnalyses>>> GetLaboratoryAnalyses();
        Task<ZabotaResult<ZabotaLaboratoryAnalyses>> GetLaboratoryAnalyseById(int id);
    }
}
