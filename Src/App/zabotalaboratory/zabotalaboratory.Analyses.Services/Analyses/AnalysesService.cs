using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using zabotalaboratory.Common.Result;
using zabotalaboratory.Common.Result.ErrorCodes;
using zabotalaboratory.Analyses.Database.Repository.Analyses;
using zabotalaboratory.Analyses.Datamodel.Analyses;
using zabotalaboratory.Analyses.Forms.AnalysesTests;
using zabotalaboratory.Analyses.Forms.AnalysesTypes;

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
        public async Task<ZabotaResult<IEnumerable<ZabotaAnalysesTypes>>> GetAnalysesTypes(bool withTests)
        {
            var result = await _analysesRepository.GetAnalysesTypes(withTests);
            if (result == null)
                return ZabotaErrorCodes.EmptyResult;

            var mappedModel = _mapper.Map<IEnumerable<ZabotaAnalysesTypes>>(result);

            return new ZabotaResult<IEnumerable<ZabotaAnalysesTypes>>(mappedModel);
        }

        public async Task<ZabotaResult<IEnumerable<ZabotaAnalysesTypesAddForm>>> GetAnalysesTypesToAddForm()
        {
            var result = await _analysesRepository.GetAnalysesTypes(false, true);
            if (result == null)
                return ZabotaErrorCodes.EmptyResult;

            foreach (var type in result) 
            {
                type.LaboratoryAnalysesTests = await _analysesRepository.GetAnalysesTestsByTypeId(type.Id, true);
            }

            var mappedModel = _mapper.Map<IEnumerable<ZabotaAnalysesTypesAddForm>>(result);

            return new ZabotaResult<IEnumerable<ZabotaAnalysesTypesAddForm>>(mappedModel);
        }

        public async Task<ZabotaResult<ZabotaAnalysesTypes>> GetAnalysesTypeById(int id)
        {
            var result = await _analysesRepository.GetAnalysesTypeById(id);
                if (result == null)
                    return ZabotaErrorCodes.EmptyResult;

            var mappedModel = _mapper.Map<ZabotaAnalysesTypes>(result);

            return new ZabotaResult<ZabotaAnalysesTypes>(mappedModel);
        }

        public async Task<ZabotaResult<bool>> AddNewAnalysesType(NewAnalysesTypeForm form)
        {
            await _analysesRepository.AddAnalysesType(form);

            return new ZabotaResult<bool>(true);
        }

        public async Task<ZabotaResult<bool>> UpdateAnalysesType(UpdateAnalysesTypeForm form)
        {
            await _analysesRepository.UpdateAnalysesType(form);

            return new ZabotaResult<bool>(true);
        }
        
        public async Task<ZabotaResult<bool>> UpdateAnalysesTypeValid(UpdateAnalysesTypeValidForm form)
        {
            await _analysesRepository.UpdateAnalysesTypeValid(form);

            return new ZabotaResult<bool>(true);
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