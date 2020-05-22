using System.Threading.Tasks;
using zabotalaboratory.Analyses.Database.Entities;
using zabotalaboratory.Common.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;
using zabotalaboratory.Analyses.Database.Context;
using zabotalaboratory.Analyses.Forms.AnalysesTests;

namespace zabotalaboratory.Analyses.Database.Repository.Analyses
{
    internal class AnalysesRepository : IAnalysesRepository
    {
        private readonly AnalysesContext _ac;

        public AnalysesRepository(AnalysesContext ac)
        {
            _ac = ac;
        }
        
        public async Task<AnalysesTypes[]> GetAnalysesTypesWithTests(bool trackChanges = false)
        {
            return await _ac.AnalysesTypes
                .HasTracking(trackChanges)
                .Include(a => a.LaboratoryAnalysesTests)
                .ToArrayAsync();
        }

        public async Task<AnalysesTypes> GetAnalysesTypeById(int id, bool trackChanges = false)
        {
            return await _ac.AnalysesTypes
                .HasTracking(trackChanges)
                .Include(a => a.LaboratoryAnalysesTests)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<LaboratoryAnalysesTests> GetAnalysesTestById(int id, bool trackChanges = false)
        {
            return await _ac.LaboratoryAnalysesTests
                .HasTracking(trackChanges)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public Task AddAnalysesTest(NewAnalysesTestForm form)
        {
            _ac.LaboratoryAnalysesTests.Add(new LaboratoryAnalysesTests
            {
                Name = form.Name,
                Number1C = form.Number1C,
                AnalysesTypesId = form.AnalysesTypesId,
                IsValid = true
            });

            return _ac.SaveChangesAsync();
        }

        public async Task UpdateAnalysesTest(UpdateAnalysesTestForm form)
        {
            var result = await GetAnalysesTestById(form.Id, true);

            result.Name = form.Name;
            result.Number1C = form.Number1C;
            result.AnalysesTypesId = form.AnalysesTypesId;

            await _ac.SaveChangesAsync();
        }

        public async Task UpdateAnalysesTestValid(UpdateAnalysesTestValidForm form)
        {
            var result = await GetAnalysesTestById(form.Id, true);

            result.IsValid = form.IsValid;

            await _ac.SaveChangesAsync();
        }
    }
}