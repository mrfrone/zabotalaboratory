﻿using System.Collections.Generic;
using System.Threading.Tasks;
using zabotalaboratory.Analyses.Datamodel.Analyses;
using zabotalaboratory.Analyses.Forms.AnalysesTests;
using zabotalaboratory.Analyses.Forms.AnalysesTypes;
using zabotalaboratory.Common.Result;

namespace zabotalaboratory.Analyses.Services.Analyses
{
    public interface IAnalysesService
    {
        #region Types

        Task<ZabotaResult<IEnumerable<ZabotaAnalysesTypes>>> GetAnalysesTypesWithoutTests();

        Task<ZabotaResult<IEnumerable<ZabotaAnalysesTypes>>> GetAnalysesTypesWithTests();

        Task<ZabotaResult<ZabotaAnalysesTypes>> GetAnalysesTypeById(int id);

        Task<ZabotaResult<bool>> AddNewAnalysesType(NewAnalysesTypeForm form);

        Task<ZabotaResult<bool>> UpdateAnalysesType(UpdateAnalysesTypeForm form);

        Task<ZabotaResult<bool>> UpdateAnalysesTypeValid(UpdateAnalysesTypeValidForm form);

        #endregion

        #region Tests

        Task<ZabotaResult<ZabotaLaboratoryAnalysesTests>> GetAnalysesTestById(int id);

        Task<ZabotaResult<bool>> AddNewAnalysesTest(NewAnalysesTestForm form);

        Task<ZabotaResult<bool>> UpdateAnalysesTest(UpdateAnalysesTestForm form);

        Task<ZabotaResult<bool>> UpdateAnalysesTestValid(UpdateAnalysesTestValidForm form);

        #endregion
    }
}
