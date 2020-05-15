using System.Threading.Tasks;
using zabotalaboratory.Analyses.Database.Entities;
using System.Collections.Generic;

namespace zabotalaboratory.Analyses.Database.Repository.LaboratoryAnalysesRepository
{
    public interface ILaboratoryAnalysesRepository
    {
        Task<List<LaboratoryAnalyses>> GetLaboratoryAnalyses(bool trackChanges = false);
    }
}