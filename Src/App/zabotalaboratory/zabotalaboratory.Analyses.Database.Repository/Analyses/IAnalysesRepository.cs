using System.Threading.Tasks;
using zabotalaboratory.Analyses.Database.Entities;
using zabotalaboratory.Analyses.Forms.AnalysesTests;

namespace zabotalaboratory.Analyses.Database.Repository.Analyses
{
    public interface IAnalysesRepository
    {
        #region Types
        Task<AnalysesTypes[]> GetAnalysesTypesWithoutTests(bool trackChanges = false);

        Task<AnalysesTypes[]> GetAnalysesTypesWithTests(bool trackChanges = false);

        Task<AnalysesTypes> GetAnalysesTypeById(int id, bool trackChanges = false);
        #endregion

        #region Tests
        Task<LaboratoryAnalysesTests> GetAnalysesTestById(int id, bool trackChanges = false);

        Task AddAnalysesTest(NewAnalysesTestForm form);

        Task UpdateAnalysesTest(UpdateAnalysesTestForm form);

        Task UpdateAnalysesTestValid(UpdateAnalysesTestValidForm form);
        #endregion
    }
}
