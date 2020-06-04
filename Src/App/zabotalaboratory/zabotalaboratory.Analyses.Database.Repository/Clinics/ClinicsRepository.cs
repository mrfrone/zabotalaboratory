using System.Threading.Tasks;
using zabotalaboratory.Common.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;
using zabotalaboratory.Analyses.Database.Context;
using System.Linq;
using zabotalaboratory.Analyses.Database.Repository.Extensions;
using zabotalaboratory.Analyses.Forms.Clinics;

namespace zabotalaboratory.Analyses.Database.Repository.Clinics
{
    internal class ClinicsRepository : IClinicsRepository
    {
        private readonly AnalysesContext _ac;

        public ClinicsRepository(AnalysesContext ac)
        {
            _ac = ac;
        }

        public async Task<Entities.Clinics[]> GetClinics(bool onlyValid, bool trackChanges = false)
        {
            return await _ac.Clinics
                .HasTracking(trackChanges)
                .HasValid(onlyValid)
                .ToArrayAsync();
        }

        public async Task<Entities.Clinics> GetClinicById(int id, bool trackChanges = false)
        {
            return await _ac.Clinics
                .HasTracking(trackChanges)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<bool> AddClinic(AddClinicForm form)
        {
            if (ClinicsNameExists(form.Name))
                return false;

            _ac.Clinics.Add(new Entities.Clinics
            {
                Name = form.Name,
                IsValid = true
            });

            await _ac.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateClinic(UpdateClinicForm form)
        {
            if (ClinicsNameExists(form.Name, form.Id))
                return false;

            var subRole = await GetClinicById(form.Id, true);

            subRole.Name = form.Name;

            await _ac.SaveChangesAsync();
            return true;
        }

        public async Task UpdateClinicValid(UpdateClinicValidForm form)
        {
            var subRole = await GetClinicById(form.Id, true);

            subRole.IsValid = form.IsValid;

            await _ac.SaveChangesAsync();
        }

        private bool ClinicsNameExists(string name, int id)
        {
            var clinic = _ac.Clinics.FirstOrDefault(r => r.Name == name && r.Id != id);
            if (clinic != null)
                return true;

            return false;
        }

        private bool ClinicsNameExists(string name)
        {
            var clinic = _ac.Clinics.FirstOrDefault(r => r.Name == name);
            if (clinic != null)
                return true;

            return false;

        }
    }
}