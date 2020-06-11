using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using zabotalaboratory.Analyses.Database.Repository.LaboratoryAnalyses;
using zabotalaboratory.Analyses.Datamodel.LaboratoryAnalyses;
using zabotalaboratory.Analyses.Datamodel.Pager;
using zabotalaboratory.Analyses.Forms.LaboratoryAnalyses;
using zabotalaboratory.Common.Result;
using zabotalaboratory.Common.Result.ErrorCodes;

namespace zabotalaboratory.Analyses.Services.LaboratoryAnalyses
{
    internal class LaboratoryAnalysesService : ILaboratoryAnalysesService
    {
        private readonly ILaboratoryAnalysesRepository _laboratoryAnalysesRepository;
        private readonly IMapper _mapper;

        public LaboratoryAnalysesService(ILaboratoryAnalysesRepository laboratoryAnalysesRepository, IMapper mapper)
        {
            _laboratoryAnalysesRepository = laboratoryAnalysesRepository;
            _mapper = mapper;
        }

        public async Task<ZabotaResult<ZabotaPager<IEnumerable<ZabotaLaboratoryAnalyses>>>> GetLaboratoryAnalyses(int page = 1, int? clinicId = null, LaboratoryAnalysesSearchForm form = null)
        {
            var result = await _laboratoryAnalysesRepository.GetLaboratoryAnalysesWithPager(clinicId, form, page);
            if (result == null)
                return ZabotaErrorCodes.EmptyResult;

            var mappedModel = new ZabotaPager<IEnumerable<ZabotaLaboratoryAnalyses>> {
                PageNumber = result.PageNumber,
                TotalPages = result.TotalPages,
                HasPreviousPage = result.HasPreviousPage,
                HasNextPage = result.HasNextPage,
                PageResult = _mapper.Map<IEnumerable<ZabotaLaboratoryAnalyses>>(result.PageResult)
            };

            return new ZabotaResult<ZabotaPager<IEnumerable<ZabotaLaboratoryAnalyses>>>(mappedModel);
        }

        public async Task<ZabotaResult<ZabotaLaboratoryAnalyses>> GetLaboratoryAnalyseById(int id)
        {
            var result = await _laboratoryAnalysesRepository.GetLaboratoryAnalysesById(id);
                if (result == null)
                    return ZabotaErrorCodes.EmptyResult;

            var mappedModel = _mapper.Map<ZabotaLaboratoryAnalyses>(result);

            return new ZabotaResult<ZabotaLaboratoryAnalyses>(mappedModel);
        }

        public async Task<ZabotaResult<bool>> AddLaboratoryAnalyse(AddLaboratoryAnalysesForm form)
        {
            await _laboratoryAnalysesRepository.AddLaboratoryAnalyse(form);

            return new ZabotaResult<bool>(true);
        }
    }
}