using System.Threading.Tasks;
using zabotalaboratory.Analyses.Forms.LaboratoryAnalyses;
using zabotalaboratory.Common.Pagination.Models;

namespace zabotalaboratory.Analyses.Database.Repository.LaboratoryAnalyses
{
    public interface ILaboratoryAnalysesRepository
    {
        Task<Pager<Entities.LaboratoryAnalyses[]>> GetLaboratoryAnalysesWithPager(int? clinicId, LaboratoryAnalysesSearchForm form, int page, bool trackChanges = false);

        Task<Entities.LaboratoryAnalyses> GetLaboratoryAnalysesById(int id, bool trackChanges = false);

        Task<int?> GetLaboratoryAnalyseId(GetLaboratoryAnalyseIdForm form, bool trackChanges = false);

        Task AddLaboratoryAnalyse(AddLaboratoryAnalysesForm form);
    }
}