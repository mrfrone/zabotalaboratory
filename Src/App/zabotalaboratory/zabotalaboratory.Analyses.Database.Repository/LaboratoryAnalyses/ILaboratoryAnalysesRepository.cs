using System.Threading.Tasks;
using zabotalaboratory.Analyses.Database.Entities;
using System.Collections.Generic;

namespace zabotalaboratory.Analyses.Database.Repository.LaboratoryAnalysesRepository
{
    public interface ILaboratoryAnalysesRepository
    {
        Task<LaboratoryAnalyses[]> GetLaboratoryAnalyses(bool trackChanges = false);
        Task<LaboratoryAnalyses> GetLaboratoryAnalysesById(int id, bool trackChanges = false);
    }
}