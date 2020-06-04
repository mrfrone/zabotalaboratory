using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;
using zabotalaboratory.Common.Result;
using zabotalaboratory.Analyses.Datamodel.Clinics;
using zabotalaboratory.Analyses.Forms.Clinics;

namespace zabotalaboratory.Analyses.Services.Clinics
{
    public interface IClinicsService
    {
        Task<ZabotaResult<IEnumerable<ZabotaClinics>>> GetClinics(bool onlyValid);

        Task<ZabotaResult<ZabotaClinics>> GetClinicById(int id);

        Task<ZabotaResult<bool>> AddClinic(AddClinicForm form);

        Task<ZabotaResult<bool>> UpdateClinic(UpdateClinicForm form);

        Task<ZabotaResult<bool>> UpdateClinicValid(UpdateClinicValidForm form);
    }
}