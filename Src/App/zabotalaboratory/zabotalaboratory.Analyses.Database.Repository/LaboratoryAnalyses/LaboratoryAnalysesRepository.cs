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

        public async Task<Pager<Entities.LaboratoryAnalyses[]>> GetLaboratoryAnalysesWithPager(int? clinicId, LaboratoryAnalysesSearchForm form, int page, bool trackChanges = false)
        {
            if (form == null)
                form = emptyForm;

            var query = _ac.LaboratoryAnalyses
                           .HasTracking(trackChanges)
                           .HasClinic(clinicId)
                           .Where(a => 
                                EF.Functions.ILike(a.LastName, $"%{form.LastName}%") && 
                                EF.Functions.ILike(a.FirstName, $"%{form.FirstName}%") && 
                                EF.Functions.ILike(a.PatronymicName, $"%{form.PatronymicName}%"))
                           .OrderByDescending(a => a.PickUpDate)
                           .Include(a => a.Clinic);

            var count = await query.CountAsync();
            int pageSize = _options.CurrentValue.PageSize;

            return new Pager<Entities.LaboratoryAnalyses[]>(count, page, pageSize, await query.Skip((page - 1) * pageSize).Take(pageSize).ToArrayAsync());
        }

        public async Task<Entities.LaboratoryAnalyses> GetLaboratoryAnalysesById(int id, bool trackChanges = false)
        {
            return await _ac.LaboratoryAnalyses
                .HasTracking(trackChanges)
                .Include(a => a.Clinic)
                .Include(a => a.Talons)
                    .ThenInclude(tal => tal.AnalysesType)
                .Include(a => a.Talons)
                    .ThenInclude(tal => tal.AnalysesResult)
                        .ThenInclude(res => res.LaboratoryAnalysesTests)
                .FirstOrDefaultAsync(a => a.Id == id);
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
            

            _ac.LaboratoryAnalyses.Add(new Entities.LaboratoryAnalyses {
                FirstName = form.FirstName,
                LastName = form.LastName,
                PatronymicName = form.PatronymicName,
                DateOfBirth = DateTime.Parse(form.DateOfBirth),
                PickUpDate = DateTime.UtcNow,
                ClinicId = form.ClinicId,
                Doctor = form.Doctor,
                Talons = talons

            });

            await _ac.SaveChangesAsync();
        }
    }
}