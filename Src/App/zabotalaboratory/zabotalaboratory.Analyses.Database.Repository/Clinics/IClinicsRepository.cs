using System.Threading.Tasks;
using zabotalaboratory.Analyses.Forms.Clinics;

namespace zabotalaboratory.Analyses.Database.Repository.Clinics
{
    public interface IClinicsRepository
    {
        Task<Entities.Clinics[]> GetClinics(bool onlyValid, bool trackChanges = false);

        Task<Entities.Clinics> GetClinicById(int id, bool trackChanges = false);

        Task<bool> AddClinic(AddClinicForm form);

        Task<bool> UpdateClinic(UpdateClinicForm form);

        Task UpdateClinicValid(UpdateClinicValidForm form);



    }
}
