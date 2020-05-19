using System.Threading.Tasks;
using zabotalaboratory.Analyses.Database.Entities;
using System.Collections.Generic;

namespace zabotalaboratory.Analyses.Database.Repository.LaboratoryAnalyses
{
    public interface ILaboratoryAnalysesRepository
    {
        Task<Entities.LaboratoryAnalyses[]> GetLaboratoryAnalyses(bool trackChanges = false);
        Task<Entities.LaboratoryAnalyses> GetLaboratoryAnalysesById(int id, bool trackChanges = false);
    }
}