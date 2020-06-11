using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zabotalaboratory.Analyses.Datamodel.LaboratoryAnalyses;
using zabotalaboratory.Analyses.Datamodel.Pager;
using zabotalaboratory.Analyses.Services.LaboratoryAnalyses;
using zabotalaboratory.Api.LaboratoryAnalyses.Forms;
using zabotalaboratory.Common;
using zabotalaboratory.Common.Consts;
using zabotalaboratory.Common.Pagination.Models;
using zabotalaboratory.Common.Result;
using zabotalaboratory.Web.Common.Filters;

namespace zabotalaboratory.Web.Areas.Api.LaboratoryAnalyses
{
    [Authorize]
    [Area(AreaNames.Api)]
    [Route(HttpRouteConsts.DefaultController)]
    public class LaboratoryAnalysesController : BaseController
    {
        private readonly ILaboratoryAnalysesService _laboratoryAnalysesService;

        public LaboratoryAnalysesController(ILaboratoryAnalysesService laboratoryAnalysesService)
        {
            _laboratoryAnalysesService = laboratoryAnalysesService;
        }

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

        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<ZabotaPager<IEnumerable<ZabotaLaboratoryAnalyses>>>> GetLaboratoryAnalyses(int id = 1)
        {
            return await _laboratoryAnalysesService.GetLaboratoryAnalyses(id, CurrentIdentity.ClinicId);
        }

        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<ZabotaLaboratoryAnalyses>> LaboratoryAnalyseById(int id)
        {
            return await _laboratoryAnalysesService.GetLaboratoryAnalyseById(id);
        }

        [ValidModelState]
        [HttpPost(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<bool>> AddLaboratoryAnalyse([FromBody] AddLaboratoryAnalysesForm form)
        {
            return await _laboratoryAnalysesService.AddLaboratoryAnalyse(new Analyses.Forms.LaboratoryAnalyses.AddLaboratoryAnalysesForm {
                FirstName = form.FirstName,
                LastName = form.LastName,
                PatronymicName = form.PatronymicName,
                DateOfBirth = form.DateOfBirth,
                ClinicId = form.ClinicId,
                Doctor = form.Doctor,
                Talons = Convert(form.Talons)
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