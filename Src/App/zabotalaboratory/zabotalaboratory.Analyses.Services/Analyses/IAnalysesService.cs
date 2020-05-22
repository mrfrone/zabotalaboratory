using System.Collections.Generic;
using System.Threading.Tasks;
using zabotalaboratory.Analyses.Datamodel.Analyses;
using zabotalaboratory.Analyses.Forms.AnalysesTests;
using zabotalaboratory.Common.Result;

namespace zabotalaboratory.Analyses.Services.Analyses
{
    public interface IAnalysesService
    {
        Task<ZabotaResult<IEnumerable<ZabotaAnalysesTypes>>> GetAnalysesTypesWithTests();

        Task<ZabotaResult<ZabotaAnalysesTypes>> GetAnalysesTypeById(int id);

        Task<ZabotaResult<ZabotaLaboratoryAnalysesTests>> GetAnalysesTestById(int id);

        Task<ZabotaResult<bool>> AddNewAnalysesTest(NewAnalysesTestForm form);

        Task<ZabotaResult<bool>> UpdateAnalysesTest(UpdateAnalysesTestForm form);

        Task<ZabotaResult<bool>> UpdateAnalysesTestValid(UpdateAnalysesTestValidForm form);
    }
}
