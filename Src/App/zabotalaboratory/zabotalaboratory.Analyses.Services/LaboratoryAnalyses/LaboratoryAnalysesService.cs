using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using zabotalaboratory.Analyses.Database.Repository.LaboratoryAnalyses;
using zabotalaboratory.Analyses.Datamodel.LaboratoryAnalyses;
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

        public async Task<ZabotaResult<IEnumerable<ZabotaLaboratoryAnalyses>>> GetLaboratoryAnalyses()
        {
            var result = await _laboratoryAnalysesRepository.GetLaboratoryAnalyses();
            if (result == null)
                return ZabotaErrorCodes.EmptyResult;

            var mappedModel = _mapper.Map<IEnumerable<ZabotaLaboratoryAnalyses>>(result);

            return new ZabotaResult<IEnumerable<ZabotaLaboratoryAnalyses>>(mappedModel);
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