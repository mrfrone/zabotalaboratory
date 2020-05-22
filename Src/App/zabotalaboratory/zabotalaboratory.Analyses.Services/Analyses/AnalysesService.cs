using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using zabotalaboratory.Common.Result;
using zabotalaboratory.Common.Result.ErrorCodes;
using zabotalaboratory.Analyses.Database.Repository.Analyses;
using zabotalaboratory.Analyses.Datamodel.Analyses;
using zabotalaboratory.Analyses.Forms.AnalysesTests;

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

        #region Types
        public async Task<ZabotaResult<IEnumerable<ZabotaAnalysesTypes>>> GetAnalysesTypesWithoutTests()
        {
            var result = await _analysesRepository.GetAnalysesTypesWithoutTests();
            if (result == null)
                return ZabotaErrorCodes.EmptyResult;

            var mappedModel = _mapper.Map<IEnumerable<ZabotaAnalysesTypes>>(result);

            return new ZabotaResult<IEnumerable<ZabotaAnalysesTypes>>(mappedModel);
        }

        public async Task<ZabotaResult<IEnumerable<ZabotaAnalysesTypes>>> GetAnalysesTypesWithTests()
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

        #endregion

        #region Tests
        public async Task<ZabotaResult<ZabotaLaboratoryAnalysesTests>> GetAnalysesTestById(int id)
        {
            var result = await _analysesRepository.GetAnalysesTestById(id);
            if (result == null)
                return ZabotaErrorCodes.EmptyResult;

            var mappedModel = _mapper.Map<ZabotaLaboratoryAnalysesTests>(result);

            return new ZabotaResult<ZabotaLaboratoryAnalysesTests>(mappedModel);
        }

        public async Task<ZabotaResult<bool>> AddNewAnalysesTest(NewAnalysesTestForm form)
        {
            await _analysesRepository.AddAnalysesTest(form);

            return new ZabotaResult<bool>(true);
        }

        public async Task<ZabotaResult<bool>> UpdateAnalysesTest(UpdateAnalysesTestForm form)
        {
            await _analysesRepository.UpdateAnalysesTest(form);

            return new ZabotaResult<bool>(true);
        }

        public async Task<ZabotaResult<bool>> UpdateAnalysesTestValid(UpdateAnalysesTestValidForm form)
        {
            await _analysesRepository.UpdateAnalysesTestValid(form);

            return new ZabotaResult<bool>(true);
        }
        #endregion
    }
}