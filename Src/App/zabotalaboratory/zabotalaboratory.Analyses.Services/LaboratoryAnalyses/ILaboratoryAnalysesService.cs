﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using zabotalaboratory.Analyses.Datamodel.LaboratoryAnalyses;
using zabotalaboratory.Analyses.Forms.LaboratoryAnalyses;
using zabotalaboratory.Common.Pagination.Datamodel;
using zabotalaboratory.Common.Result;

namespace zabotalaboratory.Analyses.Services.LaboratoryAnalyses
{
    public interface ILaboratoryAnalysesService
    {
        Task<ZabotaResult<ZabotaPager<IEnumerable<ZabotaLaboratoryAnalyses>>>> GetLaboratoryAnalyses(int page = 1, int? clinicId = null, LaboratoryAnalysesSearchForm form = null);

        Task<ZabotaResult<IEnumerable<ZabotaLaboratoryAnalyses>>> GetLaboratoryAnalysesByDate(DateTimeOffset date);

        Task<ZabotaResult<ZabotaLaboratoryAnalyses>> GetLaboratoryAnalyseById(int id);

        Task<ZabotaResult<int?>> GetLaboratoryAnalyseId(GetLaboratoryAnalyseIdForm form);

        Task<ZabotaResult<bool>> AddLaboratoryAnalyse(AddLaboratoryAnalysesForm form);

        Task<ZabotaResult<bool>> UpdateLaboratoryAnalyseValid(UpdateLaboratoryAnalysesValidForm form);

        Task<ZabotaResult<IEnumerable<ZabotaGender>>> GetGender();

        Task<ZabotaResult<ZabotaLaboratoryAnalyses>> GetLaboratoryAnalyseWithMedicalRecordById(int id);

        Task<ZabotaResult<bool>> UpdateMedicalRecord(UpdateMedicalRecordForm form);
    }
}
