using System;
using System.Threading.Tasks;
using zabotalaboratory.Analyses.Database.Entities;
using zabotalaboratory.Analyses.Forms.LaboratoryAnalyses;
using zabotalaboratory.Common.Pagination.Models;

namespace zabotalaboratory.Analyses.Database.Repository.LaboratoryAnalyses
{
    public interface ILaboratoryAnalysesRepository
    {
        Task<Pager<Entities.LaboratoryAnalyses[]>> GetLaboratoryAnalysesWithPager(int? clinicId, LaboratoryAnalysesSearchForm form, int page, bool hasValid = false, bool trackChanges = false);

        Task<Entities.LaboratoryAnalyses[]> GetLaboratoryAnalysesByDate(DateTimeOffset date, bool trackChanges = false);

        Task<Entities.LaboratoryAnalyses> GetLaboratoryAnalysesById(int id, bool trackChanges = false);

        Task<Entities.LaboratoryAnalyses> GetLaboratoryAnalyseByIdAndLastName(GetLaboratoryAnalyseIdForm form, bool trackChanges = false);

        Task AddLaboratoryAnalyse(AddLaboratoryAnalysesForm form);

        Task UpdateLaboratoryAnalysesValid(UpdateLaboratoryAnalysesValidForm form);

        Task<Gender[]> GetGenders(bool trackChanges = false);

        Task<Entities.LaboratoryAnalyses> GetLaboratoryAnalysesWithMedicalRecordById(int id, bool trackChanges = false);

        Task UpdateMedicalRecord(UpdateMedicalRecordForm form);
    }
}