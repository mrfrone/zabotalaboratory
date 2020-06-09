using System.Collections.Generic;
using System.Threading.Tasks;
using zabotalaboratory.Analyses.Database.Entities;
using zabotalaboratory.Analyses.Forms.AnalysesTests;
using zabotalaboratory.Analyses.Forms.AnalysesTypes;

namespace zabotalaboratory.Analyses.Database.Repository.Analyses
{
    public interface IAnalysesRepository
    {
        #region Types
        Task<AnalysesTypes[]> GetAnalysesTypes(bool withTests, bool onlyValid = false, bool trackChanges = false);

        Task<AnalysesTypes> GetAnalysesTypeById(int id, bool trackChanges = false);

        Task AddAnalysesType(NewAnalysesTypeForm form);

        Task UpdateAnalysesType(UpdateAnalysesTypeForm form);

        Task UpdateAnalysesTypeValid(UpdateAnalysesTypeValidForm form);

        #endregion

        #region Tests
        Task<List<LaboratoryAnalysesTests>> GetAnalysesTestsByTypeId(int typeId, bool onlyValid = false, bool trackChanges = false);

        Task<LaboratoryAnalysesTests> GetAnalysesTestById(int id, bool trackChanges = false);

        Task AddAnalysesTest(NewAnalysesTestForm form);

        Task UpdateAnalysesTest(UpdateAnalysesTestForm form);

        Task UpdateAnalysesTestValid(UpdateAnalysesTestValidForm form);
        #endregion
    }
}
