using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zabotalaboratory.Analyses.Datamodel.LaboratoryAnalyses;
using zabotalaboratory.Analyses.Services.LaboratoryAnalyses;
using zabotalaboratory.Api.LaboratoryAnalyses.Forms;
using zabotalaboratory.Common;
using zabotalaboratory.Common.Consts;
using zabotalaboratory.Common.Pagination.Datamodel;
using zabotalaboratory.Common.RazorReports.Reports.Analyses;
using zabotalaboratory.Common.Result;
using zabotalaboratory.Web.Common.Filters;
using zabotalaboratory.Web.Common.Forms;
using zabotalaboratory.Common.ExcelReports.Analyses;
using zabotalaboratory.Web.Areas.Api.LaboratoryAnalyses.Forms;
using System;

namespace zabotalaboratory.Web.Areas.Api.LaboratoryAnalyses
{
    [Area(AreaNames.Api)]
    [Route(HttpRouteConsts.DefaultController)]
    public class LaboratoryAnalysesController : BaseController
    {
        private readonly ILaboratoryAnalysesService _laboratoryAnalysesService;
        private readonly IAnalysesReportsService _analysesReportsService;
        private readonly ILaboratoryAnalysesExcelReportsService _laboratoryAnalysesExcelReportsService;

        public LaboratoryAnalysesController(ILaboratoryAnalysesService laboratoryAnalysesService,
                                            IAnalysesReportsService analysesReportsService,
                                            ILaboratoryAnalysesExcelReportsService laboratoryAnalysesExcelReportsService)
        {
            _laboratoryAnalysesService = laboratoryAnalysesService;
            _analysesReportsService = analysesReportsService;
            _laboratoryAnalysesExcelReportsService = laboratoryAnalysesExcelReportsService;
        }

        [Authorize]
        [HttpPost(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<ZabotaPager<IEnumerable<ZabotaLaboratoryAnalyses>>>> GetLaboratoryAnalyses([FromBody] LaboratoryAnalysesSearchForm form)
        {
            return await _laboratoryAnalysesService.GetLaboratoryAnalyses(form.Page, CurrentIdentity.ClinicId, new Analyses.Forms.LaboratoryAnalyses.LaboratoryAnalysesSearchForm {
                FirstName = form.FirstName,
                LastName = form.LastName,
                PatronymicName = form.PatronymicName,
                PickUpDate = form.PickUpDate
            });
        }

        [Authorize]
        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<ZabotaPager<IEnumerable<ZabotaLaboratoryAnalyses>>>> GetLaboratoryAnalyses(int id = 1)
        {
            return await _laboratoryAnalysesService.GetLaboratoryAnalyses(id, CurrentIdentity.ClinicId);
        }

        [HttpPost(HttpRouteConsts.DefaultAction)]
        public async Task<IActionResult> GetLaboratoryAnalyseReportById([FromBody] DownloadFileByIdForm form)
        {
            var result = await _analysesReportsService.GetAnalysesResultReportById(form.Id);

            return File(result.Result, "application/pdf", "pdf-report");
        }

        [Authorize]
        [HttpPost(HttpRouteConsts.DefaultAction)]
        public async Task<IActionResult> GetLaboratoryAnalyseExcelReportByDate([FromBody] DownloadFileByDateForm form)
        {
            var result = await _laboratoryAnalysesExcelReportsService.GetLaboratoryAnalysesExcelReportByDate(DateTimeOffset.Parse(form.Date));

            return File(result.Result, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "excel-report");
        }

        [HttpPost(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<int?>> LaboratoryAnalyseId([FromBody] GetLaboratoryAnalyseIdForm form)
        {
            return await _laboratoryAnalysesService.GetLaboratoryAnalyseId(new Analyses.Forms.LaboratoryAnalyses.GetLaboratoryAnalyseIdForm {
                Id = form.Id,
                LastName = form.LastName
            });
        }

        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<ZabotaLaboratoryAnalyses>> LaboratoryAnalyseById(int id)
        {
            return await _laboratoryAnalysesService.GetLaboratoryAnalyseById(id);
        }

        [Authorize]
        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<ZabotaLaboratoryAnalyses>> LaboratoryAnalyseWithMedicalRecordById(int id)
        {
            return await _laboratoryAnalysesService.GetLaboratoryAnalyseWithMedicalRecordById(id);
        }

        [Authorize]
        [HttpPost(HttpRouteConsts.DefaultAction)]
        public async Task<IActionResult> GetMedicalRecordReportById([FromBody] DownloadFileByIdForm form)
        {
            var result = await _analysesReportsService.GetMedicalRecordReportById(form.Id);

            return File(result.Result, "application/pdf", "pdf-report");
        }

        [Authorize]
        [ValidModelState]
        [HttpPost(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<bool>> UpdateMedicalRecord([FromBody] UpdateMedicalRecordForm form)
        {
            return await _laboratoryAnalysesService.UpdateMedicalRecord(new Analyses.Forms.LaboratoryAnalyses.UpdateMedicalRecordForm { 
                Id = form.Id,
                InsuranceName = form.InsuranceName,
                PolicyNumber = form.PolicyNumber,
                SnilsNumber = form.SnilsNumber,
                PrivilegeCode = form.PrivilegeCode,
                PermanentAddress = form.PermanentAddress,
                ActualAddress = form.ActualAddress,
                PhoneNumber = form.PhoneNumber,
                PreferentialProvision = form.PreferentialProvision,
                Disability = form.Disability,
                PlaceOfWork = form.PlaceOfWork,
                Profession = form.Profession,
                Position = form.Position,
                Dependent = form.Dependent
            });
        }

        [Authorize]
        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<IEnumerable<ZabotaGender>>> GetGenders()
        {
            return await _laboratoryAnalysesService.GetGender();
        }

        [Authorize]
        [ValidModelState]
        [HttpPost(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<bool>> AddLaboratoryAnalyse([FromBody] AddLaboratoryAnalysesForm form)
        {
            return await _laboratoryAnalysesService.AddLaboratoryAnalyse(new Analyses.Forms.LaboratoryAnalyses.AddLaboratoryAnalysesForm {
                FirstName = form.FirstName,
                LastName = form.LastName,
                PatronymicName = form.PatronymicName,
                GenderId = form.GenderId,
                DateOfBirth = form.DateOfBirth,
                ClinicId = form.ClinicId,
                Doctor = form.Doctor,
                Talons = Convert(form.Talons)
            }); 
        }

        [Authorize]
        [ValidModelState]
        [HttpPost(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<bool>> UpdateLaboratoryAnalyseValid([FromBody] UpdateLaboratoryAnalysesValidForm form)
        {
            return await _laboratoryAnalysesService.UpdateLaboratoryAnalyseValid(new Analyses.Forms.LaboratoryAnalyses.UpdateLaboratoryAnalysesValidForm
            {
                Id = form.Id,
                IsValid = form.IsValid
            });
        }

        private IEnumerable<Analyses.Forms.LaboratoryAnalyses.AddTalonsForm> Convert(IEnumerable<AddTalonsForm> source)
        {
            var talons = new List<Analyses.Forms.LaboratoryAnalyses.AddTalonsForm>();

            foreach (var talon in source)
            {
                if (talon.IsNeeded)
                {
                    var results = new List<Analyses.Forms.LaboratoryAnalyses.AddAnalysesResultForm>();
                    foreach (var result in talon.AnalysesResult)
                    {
                        if (result.IsNeeded)
                            results.Add(new Analyses.Forms.LaboratoryAnalyses.AddAnalysesResultForm
                            {
                                LaboratoryAnalysesTestsId = result.LaboratoryAnalysesTestsId
                            });
                    }

                    talons.Add(new Analyses.Forms.LaboratoryAnalyses.AddTalonsForm
                    {
                        AnalysesTypeId = talon.AnalysesTypeId,
                        AnalysesResult = results
                    });
                }
            }

            return talons;
        }
    }
}