using System.Threading.Tasks;
using zabotalaboratory.Analyses.Database.Entities;

namespace zabotalaboratory.Analyses.Database.Repository.Analyses
{
    public interface IAnalysesRepository
    {

        Task<AnalysesTypes[]> GetAnalysesTypesWithTests(bool trackChanges = false);

        Task<AnalysesTypes> GetAnalysesTypeById(int id, bool trackChanges = false);
    }
}
