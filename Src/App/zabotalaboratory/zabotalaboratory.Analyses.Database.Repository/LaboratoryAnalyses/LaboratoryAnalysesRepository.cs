using System.Threading.Tasks;
using zabotalaboratory.Analyses.Database.Entities;
using zabotalaboratory.Common.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;
using zabotalaboratory.Analyses.Database.Context;
using System.Linq;
using zabotalaboratory.Analyses.Forms.LaboratoryAnalyses;
using System;
using System.Collections.Generic;
using zabotalaboratory.Common.Pagination.Models;
using Microsoft.Extensions.Options;
using zabotalaboratory.Common.Datamodel.Pager;
using zabotalaboratory.Analyses.Database.Repository.Extentions;

namespace zabotalaboratory.Analyses.Database.Repository.LaboratoryAnalyses
{
    internal class LaboratoryAnalysesRepository : ILaboratoryAnalysesRepository
    {
        private readonly LaboratoryAnalysesSearchForm emptyForm = new LaboratoryAnalysesSearchForm {
            LastName = "",
            FirstName = "",
            PatronymicName = ""
        };

        private readonly IOptionsMonitor<PagerSettings> _options;
        private readonly AnalysesContext _ac;

        public LaboratoryAnalysesRepository(AnalysesContext ac, IOptionsMonitor<PagerSettings> options)
        {
            _ac = ac;
            _options = options;
        }

        public async Task<Pager<Entities.LaboratoryAnalyses[]>> GetLaboratoryAnalysesWithPager(int? clinicId, LaboratoryAnalysesSearchForm form, int page, bool hasValid = false, bool trackChanges = false)
        {
            if (form == null)
                form = emptyForm;

            var query = _ac.LaboratoryAnalyses
                           .HasTracking(trackChanges)
                           .HasClinic(clinicId)
                           .HasValid(hasValid)
                           .Where(a => 
                                EF.Functions.ILike(a.LastName, $"%{form.LastName}%") && 
                                EF.Functions.ILike(a.FirstName, $"%{form.FirstName}%") && 
                                EF.Functions.ILike(a.PatronymicName, $"%{form.PatronymicName}%"))
                           .OrderByDescending(a => a.PickUpDate)
                           .Include(a => a.Clinic)
                           .Include(a => a.Gender);

            var count = await query.CountAsync();
            int pageSize = _options.CurrentValue.PageSize;

            return new Pager<Entities.LaboratoryAnalyses[]>(count, page, pageSize, await query.Skip((page - 1) * pageSize).Take(pageSize).ToArrayAsync());
        }

        public async Task<Entities.LaboratoryAnalyses[]> GetLaboratoryAnalysesByDate(DateTimeOffset date, bool trackChanges = false)
        {
            return await _ac.LaboratoryAnalyses
                            .Where(a => a.PickUpDate >= date && a.PickUpDate <= date.AddDays(1))
                            .HasTracking(trackChanges)
                            .Include(a => a.Gender)
                            .Include(a => a.Clinic)
                            .Include(a => a.Talons)
                                .ThenInclude(tal => tal.AnalysesType)
                            .Include(a => a.Talons)
                                .ThenInclude(tal => tal.AnalysesResult)
                                    .ThenInclude(res => res.LaboratoryAnalysesTests)
                            .ToArrayAsync();
        }

        public async Task<Entities.LaboratoryAnalyses> GetLaboratoryAnalysesById(int id, bool trackChanges = false)
        {
            return await _ac.LaboratoryAnalyses
                .HasTracking(trackChanges)
                .Include(a => a.Gender)
                .Include(a => a.Clinic)
                .Include(a => a.Talons)
                    .ThenInclude(tal => tal.AnalysesType)
                .Include(a => a.Talons)
                    .ThenInclude(tal => tal.AnalysesResult)
                        .ThenInclude(res => res.LaboratoryAnalysesTests)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Entities.LaboratoryAnalyses> GetLaboratoryAnalyseByIdAndLastName(GetLaboratoryAnalyseIdForm form, bool trackChanges = false)
        {
            return await _ac.LaboratoryAnalyses
                .HasTracking(trackChanges)
                .Where(a => a.Id == form.Id && a.LastName == form.LastName)
                .FirstOrDefaultAsync();
        }

        public async Task AddLaboratoryAnalyse(AddLaboratoryAnalysesForm form)
        {
            var talons = new List<Talons>();

            foreach(var talon in form.Talons)
            {
                    var results = new List<AnalysesResult>();
                    foreach (var result in talon.AnalysesResult)
                    {
                            results.Add(new AnalysesResult
                            {
                                LaboratoryAnalysesTestsId = result.LaboratoryAnalysesTestsId
                            });
                    }

                    talons.Add(new Talons
                    {
                        AnalysesTypeId = talon.AnalysesTypeId,
                        AnalysesResult = results
                    });
            }                                  

            _ac.LaboratoryAnalyses.Add(new Entities.LaboratoryAnalyses
            {
                FirstName = form.FirstName,
                LastName = form.LastName,
                PatronymicName = form.PatronymicName,
                GenderId = form.GenderId,
                DateOfBirth = DateTime.Parse(form.DateOfBirth),
                PickUpDate = DateTime.UtcNow,
                ClinicId = form.ClinicId,
                Doctor = form.Doctor,
                Talons = talons,
                IsValid = true,
                MedicalRecord = new MedicalRecord
                {
                    InsuranceName = "-",
                    PolicyNumber = "-",
                    SnilsNumber = "-",
                    PrivilegeCode = "-",
                    PermanentAddress = "-",
                    ActualAddress = "-",
                    PhoneNumber = "-",
                    PreferentialProvision = "-",
                    Disability = "-",
                    PlaceOfWork = "не указано",
                    Profession = "не указано",
                    Position = "не указано",
                    Dependent = "-"
                }
            });

            await _ac.SaveChangesAsync();
        }

        public async Task UpdateLaboratoryAnalysesValid(UpdateLaboratoryAnalysesValidForm form)
        {
            var result = await _ac.LaboratoryAnalyses.FirstOrDefaultAsync(a => a.Id == form.Id);
            if (result == null)
                return;

            result.IsValid = form.IsValid;

            await _ac.SaveChangesAsync();
        }

        public async Task<Gender[]> GetGenders(bool trackChanges = false)
        {
            return await _ac.Gender
                .HasTracking(trackChanges)
                .ToArrayAsync();
        }

        public async Task<Entities.LaboratoryAnalyses> GetLaboratoryAnalysesWithMedicalRecordById(int id, bool trackChanges = false)
        {
            return await _ac.LaboratoryAnalyses
                .HasTracking(trackChanges)
                .Include(a => a.Gender)
                .Include(a => a.MedicalRecord)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task UpdateMedicalRecord(UpdateMedicalRecordForm form)
        {
            var record = await _ac.MedicalRecord
                .HasTracking(true)
                .FirstOrDefaultAsync(r => r.LaboratoryAnalysesId == form.Id);

            record.InsuranceName = form.InsuranceName;
            record.PolicyNumber = form.PolicyNumber;
            record.SnilsNumber = form.SnilsNumber;
            record.PrivilegeCode = form.PrivilegeCode;
            record.PermanentAddress = form.PermanentAddress;
            record.ActualAddress = form.ActualAddress;
            record.PhoneNumber = form.PhoneNumber;
            record.PreferentialProvision = form.PreferentialProvision;
            record.Disability = form.Disability;
            record.PlaceOfWork = form.PlaceOfWork;
            record.Profession = form.Profession;
            record.Position = form.Position;
            record.Dependent = form.Dependent;

            await _ac.SaveChangesAsync();
        }
    }
}