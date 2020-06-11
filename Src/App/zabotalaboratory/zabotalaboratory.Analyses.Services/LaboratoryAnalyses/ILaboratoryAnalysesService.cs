﻿using System.Collections.Generic;
using System.Threading.Tasks;
using zabotalaboratory.Analyses.Datamodel.LaboratoryAnalyses;
using zabotalaboratory.Analyses.Datamodel.Pager;
using zabotalaboratory.Analyses.Forms.LaboratoryAnalyses;
using zabotalaboratory.Common.Result;

namespace zabotalaboratory.Analyses.Services.LaboratoryAnalyses
{
    public interface ILaboratoryAnalysesService
    {
        Task<ZabotaResult<ZabotaPager<IEnumerable<ZabotaLaboratoryAnalyses>>>> GetLaboratoryAnalyses(int page = 1, int? clinicId = null, LaboratoryAnalysesSearchForm form = null);

        Task<ZabotaResult<ZabotaLaboratoryAnalyses>> GetLaboratoryAnalyseById(int id);

        Task<ZabotaResult<bool>> AddLaboratoryAnalyse(AddLaboratoryAnalysesForm form);
    }
}
