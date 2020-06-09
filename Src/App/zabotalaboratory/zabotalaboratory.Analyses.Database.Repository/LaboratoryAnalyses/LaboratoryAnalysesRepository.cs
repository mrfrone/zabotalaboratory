using System.Threading.Tasks;
using zabotalaboratory.Analyses.Database.Entities;
using zabotalaboratory.Common.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;
using zabotalaboratory.Analyses.Database.Context;
using System.Linq;
using zabotalaboratory.Analyses.Forms.LaboratoryAnalyses;
using System;
using System.Collections.Generic;

namespace zabotalaboratory.Analyses.Database.Repository.LaboratoryAnalyses
{
    internal class LaboratoryAnalysesRepository : ILaboratoryAnalysesRepository
    {
        private readonly AnalysesContext _ac;

        public LaboratoryAnalysesRepository(AnalysesContext ac)
        {
            _ac = ac;
        }
        
        public async Task<Entities.LaboratoryAnalyses[]> GetLaboratoryAnalyses(bool trackChanges = false)
        {
            return await _ac.LaboratoryAnalyses
                .HasTracking(trackChanges)
                .Include(a => a.Clinic)
                .ToArrayAsync();
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