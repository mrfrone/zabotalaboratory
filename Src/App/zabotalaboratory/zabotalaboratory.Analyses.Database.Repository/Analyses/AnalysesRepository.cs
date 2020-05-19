using System.Threading.Tasks;
using zabotalaboratory.Analyses.Database.Entities;
using zabotalaboratory.Common.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;
using zabotalaboratory.Analyses.Database.Context;

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


    }
}