using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;
using zabotalaboratory.Common.Result;
using zabotalaboratory.Common.Result.ErrorCodes;
using zabotalaboratory.Analyses.Database.Repository.Clinics;
using zabotalaboratory.Analyses.Datamodel.Clinics;
using zabotalaboratory.Analyses.Forms.Clinics;

namespace zabotalaboratory.Analyses.Services.Clinics
{
    internal class ClinicsService : IClinicsService
    {
        private readonly IClinicsRepository _clinicsRepository;
        private readonly IMapper _mapper;

        public ClinicsService(IClinicsRepository clinicsRepository, IMapper mapper)
        {
            _clinicsRepository = clinicsRepository;
            _mapper = mapper;
        }

        public async Task<ZabotaResult<IEnumerable<ZabotaClinics>>> GetClinics(bool onlyValid)
        {
            var model = await _clinicsRepository.GetClinics(onlyValid);
            var mappedModel = _mapper.Map<IEnumerable<ZabotaClinics>>(model);

            return new ZabotaResult<IEnumerable<ZabotaClinics>>(mappedModel);
        }

        public async Task<ZabotaResult<ZabotaClinics>> GetClinicById(int id)
        {
            var model = await _clinicsRepository.GetClinicById(id);
            var mappedModel = _mapper.Map<ZabotaClinics>(model);

            return new ZabotaResult<ZabotaClinics>(mappedModel);
        }

        public async Task<ZabotaResult<bool>> AddClinic(AddClinicForm form)
        {
            var result = await _clinicsRepository.AddClinic(form);
            if (result != true)
                return ZabotaErrorCodes.AddClinicOperationError;

            return new ZabotaResult<bool>(true);
        }

        public async Task<ZabotaResult<bool>> UpdateClinic(UpdateClinicForm form)
        {
            var result = await _clinicsRepository.UpdateClinic(form);
            if (result != true)
                return ZabotaErrorCodes.UpdateClinicOperationError;

            return new ZabotaResult<bool>(true);
        }

        public async Task<ZabotaResult<bool>> UpdateClinicValid(UpdateClinicValidForm form)
        {
            var result = await _clinicsRepository.GetClinicById(form.Id);
            if (result == null)
                return ZabotaErrorCodes.CannotFindClinicById;

            await _clinicsRepository.UpdateClinicValid(form);

            return new ZabotaResult<bool>(true);
        }
    }
}