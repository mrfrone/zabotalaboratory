using System.Threading.Tasks;
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
        public async Task<AnalysesTypes[]> GetAnalysesTypes(bool onlyValid = false, bool trackChanges = false)
        {
            return await _ac.AnalysesTypes
                .AsQueryable()
                .HasTracking(trackChanges)
                .OrderBy(t => t.NumberInOrder)
                .HasValid(onlyValid)
                .ToArrayAsync();
        }

        public async Task<AnalysesTypes> GetAnalysesTypeById(int id, bool trackChanges = false)
        {
            return await _ac.AnalysesTypes
                .HasTracking(trackChanges)
                //.Include(a => a.LaboratoryAnalysesTests)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAnalysesType(NewAnalysesTypeForm form)
        {
            _ac.AnalysesTypes.Add(new AnalysesTypes
            {
                Name = form.Name,
                ExcelName = form.ExcelName,
                PDFName = form.PDFName,
                Number1C = form.Number1C,
                NumberInOrder = _ac.AnalysesTypes.Max(t => t.NumberInOrder) + 1,
                IsValid = true,
                BioMaterial = form.BioMaterial
            });

            await _ac.SaveChangesAsync();
        }

        public async Task UpdateAnalysesType(UpdateAnalysesTypeForm form)
        {
            var result = await GetAnalysesTypeById(form.Id, true);

            result.Name = form.Name;
            result.ExcelName = form.ExcelName;
            result.PDFName = form.PDFName;
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

        public async Task UpdateAnalysesTypeNumber(UpdateTypesNumberInOrderForm form)
        {
            if(form.IsUp)
                if (form.NumberInOrder <= 1)
                    return;

            int number;

            if (form.IsUp)
                number = -1;
            else
                number = 1;

            var mainModel = await _ac.AnalysesTypes
                                     .HasTracking(true)
                                     .FirstOrDefaultAsync(t => t.NumberInOrder == form.NumberInOrder);

            var subModel = await _ac.AnalysesTypes
                                    .HasTracking(true)
                                    .FirstOrDefaultAsync(t => t.NumberInOrder == (form.NumberInOrder + number));

            if (subModel == null || mainModel == null)
                return;

            int numberStorage = mainModel.NumberInOrder;
            mainModel.NumberInOrder = subModel.NumberInOrder;
            subModel.NumberInOrder = numberStorage;

            await _ac.SaveChangesAsync();
        }

        #endregion

        #region Tests

        public async Task<List<LaboratoryAnalysesTests>> GetAnalysesTestsByTypeId(int typeId, bool onlyValid = false, bool trackChanges = false) 
        {
            return await _ac.LaboratoryAnalysesTests
                .HasTracking(trackChanges)
                .Where(t => t.AnalysesTypesId == typeId)
                .OrderBy(t => t.NumberInOrder)
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
                ExcelName = form.ExcelName,
                PDFName = form.PDFName,
                Number1C = form.Number1C,
                NumberInOrder = _ac.LaboratoryAnalysesTests.Where(t => t.AnalysesTypesId == form.AnalysesTypesId).Max(t => t.NumberInOrder) + 1,
                AnalysesTypesId = form.AnalysesTypesId,
                IsValid = true
            });

            await _ac.SaveChangesAsync();
        }

        public async Task UpdateAnalysesTest(UpdateAnalysesTestForm form)
        {
            var result = await GetAnalysesTestById(form.Id, true);

            result.Name = form.Name;
            result.ExcelName = form.ExcelName;
            result.PDFName = form.PDFName;
            result.Number1C = form.Number1C;
            result.AnalysesTypesId = form.AnalysesTypesId;

            await _ac.SaveChangesAsync();
        }

        public async Task UpdateAnalysesTestValid(UpdateAnalysesTestValidForm form)
        {
            var result = await GetAnalysesTestById(form.Id, true);

            result.IsValid = form.IsValid;

            await _ac.SaveChangesAsync();
        }

        public async Task UpdateAnalysesTestNumber(UpdateTestsNumberInOrderForm form)
        {
            if (form.IsUp)
                if (form.NumberInOrder <= 1)
                    return;

            int number;

            if (form.IsUp)
                number = -1;
            else
                number = 1;

            var mainModel = await _ac.LaboratoryAnalysesTests
                                     .HasTracking(true)
                                     .FirstOrDefaultAsync(t => t.AnalysesTypesId == form.TypeId && t.NumberInOrder == form.NumberInOrder);

            var subModel = await _ac.LaboratoryAnalysesTests
                                    .HasTracking(true)
                                    .FirstOrDefaultAsync(t => t.AnalysesTypesId == form.TypeId && t.NumberInOrder == (form.NumberInOrder + number));

            if (subModel == null || mainModel == null)
                return;

            int numberStorage = mainModel.NumberInOrder;
            mainModel.NumberInOrder = subModel.NumberInOrder;
            subModel.NumberInOrder = numberStorage;

            await _ac.SaveChangesAsync();
        }
        #endregion
    }
}