using System.Collections.Generic;
using System.Threading.Tasks;
using zabotalaboratory.Analyses.Datamodel.Analyses;
using zabotalaboratory.Analyses.Forms.AnalysesTests;
using zabotalaboratory.Common.Result;

namespace zabotalaboratory.Analyses.Services.Analyses
{
    public interface IAnalysesService
    {
        #region Types

        Task<ZabotaResult<IEnumerable<ZabotaAnalysesTypes>>> GetAnalysesTypesWithoutTests();

        Task<ZabotaResult<IEnumerable<ZabotaAnalysesTypes>>> GetAnalysesTypesWithTests();

        Task<ZabotaResult<ZabotaAnalysesTypes>> GetAnalysesTypeById(int id);

        #endregion

        #region Tests

        Task<ZabotaResult<ZabotaLaboratoryAnalysesTests>> GetAnalysesTestById(int id);

        Task<ZabotaResult<bool>> AddNewAnalysesTest(NewAnalysesTestForm form);

        Task<ZabotaResult<bool>> UpdateAnalysesTest(UpdateAnalysesTestForm form);

        Task<ZabotaResult<bool>> UpdateAnalysesTestValid(UpdateAnalysesTestValidForm form);

        #endregion
    }
}
