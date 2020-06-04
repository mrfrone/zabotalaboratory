using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using zabotalaboratory.Analyses.Datamodel.Clinics;
using zabotalaboratory.Analyses.Services.Clinics;
using zabotalaboratory.Api.Clinics.Forms;
using zabotalaboratory.Common;
using zabotalaboratory.Common.Consts;
using zabotalaboratory.Common.Consts.Roles;
using zabotalaboratory.Common.Result;
using zabotalaboratory.Web.Common.Filters;

namespace zabotalaboratory.Web.Areas.Api.Clinics
{
    [Authorize(Roles = Roles.Admin + ", " + Roles.Laborant)]
    [Area(AreaNames.Api)]
    [Route(HttpRouteConsts.DefaultController)]
    public class ClinicsController : BaseController
    {
        private readonly IClinicsService _clinicsService;

        public ClinicsController(IClinicsService clinicsService)
        {
            _clinicsService = clinicsService;
        }

        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<IEnumerable<ZabotaClinics>>> GetOnlyValidClinics()
        {
            return await _clinicsService.GetClinics(true);
        }

        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<IEnumerable<ZabotaClinics>>> GetClinics()
        {
            return await _clinicsService.GetClinics(false);
        }

        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<ZabotaClinics>> GetClinicById(int id)
        {
            return await _clinicsService.GetClinicById(id);
        }

        [ValidModelState]
        [HttpPost(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<bool>> AddClinic([FromBody] AddClinicForm form)
        {
            return await _clinicsService.AddClinic(new Analyses.Forms.Clinics.AddClinicForm
            {
                Name = form.Name
            });
        }

        [ValidModelState]
        [HttpPost(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<bool>> UpdateClinic([FromBody] UpdateClinicForm form)
        {
            return await _clinicsService.UpdateClinic(new Analyses.Forms.Clinics.UpdateClinicForm
            {
                Id = form.Id,
                Name = form.Name
            });
        }

        [ValidModelState]
        [HttpPost(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<bool>> UpdateClinicValid([FromBody] UpdateClinicValidForm form)
        {
            return await _clinicsService.UpdateClinicValid(new Analyses.Forms.Clinics.UpdateClinicValidForm
            {
                Id = form.Id,
                IsValid = form.IsValid
            });
        }
    }
}