using System.Threading.Tasks;
using zabotalaboratory.Analyses.Database.Entities;
using zabotalaboratory.Common.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;
using zabotalaboratory.Analyses.Database.Context;

namespace zabotalaboratory.Analyses.Database.Repository.LaboratoryAnalysesRepository
{
    internal class LaboratoryAnalysesRepository : ILaboratoryAnalysesRepository
    {
        private readonly AnalysesContext _ac;

        public LaboratoryAnalysesRepository(AnalysesContext ac)
        {
            _ac = ac;
        }
        
        public async Task<LaboratoryAnalyses[]> GetLaboratoryAnalyses(bool trackChanges = false)
        {
            return await _ac.LaboratoryAnalyses
                .HasTracking(trackChanges)
                .Include(a => a.Clinic)
                .ToArrayAsync();
        }
        public async Task<LaboratoryAnalyses> GetLaboratoryAnalysesById(int id, bool trackChanges = false)
        {
            return await _ac.LaboratoryAnalyses
                .HasTracking(trackChanges)
                .Include(a => a.Clinic)
                .Include(a => a.Talons)
                    .ThenInclude(tal => tal.AnalysesType)
                .Include(a => a.Talons)
                    .ThenInclude(tal => tal.AnalysesResult)
                        .ThenInclude(res => res.LaboratoryAnalysesTests)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}