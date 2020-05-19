using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using zabotalaboratory.Common.Result;
using zabotalaboratory.Common.Result.ErrorCodes;
using zabotalaboratory.Analyses.Database.Repository.Analyses;
using zabotalaboratory.Analyses.Datamodel.Analyses;

namespace zabotalaboratory.Analyses.Services.Analyses
{
    internal class AnalysesService : IAnalysesService
    {
        private readonly IAnalysesRepository _analysesRepository;
        private readonly IMapper _mapper;

        public AnalysesService(IAnalysesRepository analysesRepository, IMapper mapper)
        {
            _analysesRepository = analysesRepository;
            _mapper = mapper;
        }

        public async Task<ZabotaResult<IEnumerable<ZabotaAnalysesTypes>>> GetAnalysesWithTests()
        {
            var result = await _analysesRepository.GetAnalysesTypesWithTests();
            if (result == null)
                return ZabotaErrorCodes.EmptyResult;

            var mappedModel = _mapper.Map<IEnumerable<ZabotaAnalysesTypes>>(result);

            return new ZabotaResult<IEnumerable<ZabotaAnalysesTypes>>(mappedModel);
        }

        public async Task<ZabotaResult<ZabotaAnalysesTypes>> GetAnalysesTypeById(int id)
        {
            var result = await _analysesRepository.GetAnalysesTypeById(id);
                if (result == null)
                    return ZabotaErrorCodes.EmptyResult;

            var mappedModel = _mapper.Map<ZabotaAnalysesTypes>(result);

            return new ZabotaResult<ZabotaAnalysesTypes>(mappedModel);
        }
    }
}