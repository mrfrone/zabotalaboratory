using System.Threading.Tasks;
using zabotalaboratory.Analyses.Database.Entities;
using zabotalaboratory.Analyses.Forms.AnalysesTests;

namespace zabotalaboratory.Analyses.Database.Repository.Analyses
{
    public interface IAnalysesRepository
    {

        Task<AnalysesTypes[]> GetAnalysesTypesWithTests(bool trackChanges = false);

        Task<AnalysesTypes> GetAnalysesTypeById(int id, bool trackChanges = false);

        Task<LaboratoryAnalysesTests> GetAnalysesTestById(int id, bool trackChanges = false);

        Task AddAnalysesTest(NewAnalysesTestForm form);

        Task UpdateAnalysesTest(UpdateAnalysesTestForm form);

        Task UpdateAnalysesTestValid(UpdateAnalysesTestValidForm form);
    }
}
