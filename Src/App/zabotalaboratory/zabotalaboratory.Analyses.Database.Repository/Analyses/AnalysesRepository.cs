﻿using System.Threading.Tasks;
using zabotalaboratory.Analyses.Database.Entities;
using zabotalaboratory.Common.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;
using zabotalaboratory.Analyses.Database.Context;
using zabotalaboratory.Analyses.Forms.AnalysesTests;
using zabotalaboratory.Analyses.Forms.AnalysesTypes;
using System.Linq;
using System.Collections.Generic;

namespace zabotalaboratory.Analyses.Database.Repository.Analyses
{
    internal class AnalysesRepository : IAnalysesRepository
    {
        private readonly AnalysesContext _ac;

        public AnalysesRepository(AnalysesContext ac)
        {
            _ac = ac;
        }

        #region Types
        public async Task<AnalysesTypes[]> GetAnalysesTypes(bool withTests, bool onlyValid = false, bool trackChanges = false)
        {
            var query = _ac.AnalysesTypes
                .AsQueryable()
                .HasTracking(trackChanges)
                .OrderBy(t => t.Id)
                .HasValid(onlyValid);

            if (withTests)
            {
                query = query.Include(u => u.LaboratoryAnalysesTests);
            }

            return await query.ToArrayAsync();
        }

        public async Task<AnalysesTypes> GetAnalysesTypeById(int id, bool trackChanges = false)
        {
            return await _ac.AnalysesTypes
                .HasTracking(trackChanges)
                .Include(a => a.LaboratoryAnalysesTests)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAnalysesType(NewAnalysesTypeForm form)
        {
            _ac.AnalysesTypes.Add(new AnalysesTypes
            {
                Name = form.Name,
                Number1C = form.Number1C,
                IsValid = true,
                BioMaterial = form.BioMaterial
            });

            await _ac.SaveChangesAsync();
        }

        public async Task UpdateAnalysesType(UpdateAnalysesTypeForm form)
        {
            var result = await GetAnalysesTypeById(form.Id, true);

            result.Name = form.Name;
            result.Number1C = form.Number1C;
            result.BioMaterial = form.BioMaterial;

            await _ac.SaveChangesAsync();
        }
        
        public async Task UpdateAnalysesTypeValid(UpdateAnalysesTypeValidForm form)
        {
            var result = await GetAnalysesTypeById(form.Id, true);

            result.IsValid = form.IsValid;

            await _ac.SaveChangesAsync();
        }
        
        #endregion

        #region Tests
        
        public async Task<List<LaboratoryAnalysesTests>> GetAnalysesTestsByTypeId(int typeId, bool onlyValid = false, bool trackChanges = false) 
        {
            return await _ac.LaboratoryAnalysesTests
                .HasTracking(trackChanges)
                .Where(t => t.AnalysesTypesId == typeId)
                .OrderBy(t => t.Id)
                .HasValid(onlyValid)
                .ToListAsync();
        }
        
        public async Task<LaboratoryAnalysesTests> GetAnalysesTestById(int id, bool trackChanges = false)
        {
            return await _ac.LaboratoryAnalysesTests
                .HasTracking(trackChanges)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAnalysesTest(NewAnalysesTestForm form)
        {
            _ac.LaboratoryAnalysesTests.Add(new LaboratoryAnalysesTests
            {
                Name = form.Name,
                Number1C = form.Number1C,
                AnalysesTypesId = form.AnalysesTypesId,
                IsValid = true,
                ReferenceLimits = form.ReferenceLimits,
                Units = form.Units
            });

            await _ac.SaveChangesAsync();
        }

        public async Task UpdateAnalysesTest(UpdateAnalysesTestForm form)
        {
            var result = await GetAnalysesTestById(form.Id, true);

            result.Name = form.Name;
            result.Number1C = form.Number1C;
            result.AnalysesTypesId = form.AnalysesTypesId;
            result.Units = form.Units;
            result.ReferenceLimits = form.ReferenceLimits;

            await _ac.SaveChangesAsync();
        }

        public async Task UpdateAnalysesTestValid(UpdateAnalysesTestValidForm form)
        {
            var result = await GetAnalysesTestById(form.Id, true);

            result.IsValid = form.IsValid;

            await _ac.SaveChangesAsync();
        }
        #endregion
    }
}