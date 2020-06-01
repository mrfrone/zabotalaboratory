using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zabotalaboratory.Analyses.Datamodel.Analyses;
using zabotalaboratory.Analyses.Services.Analyses;
using zabotalaboratory.Common;
using zabotalaboratory.Common.Consts;
using zabotalaboratory.Common.Consts.Roles;
using zabotalaboratory.Common.Result;
using zabotalaboratory.Web.Areas.Api.AnalysesTypes.Forms;
using zabotalaboratory.Web.Common.Filters;

namespace zabotalaboratory.Web.Areas.Api.AnalysesTypes
{
    [Authorize(Roles = Roles.Admin + ", " + Roles.Laborant)]
    [Area(AreaNames.Api)]
    [Route(HttpRouteConsts.DefaultController)]
    public class AnalysesTypesController : BaseController
    {
        private readonly IAnalysesService _analysesService;

        public AnalysesTypesController(IAnalysesService analysesService)
        {
            _analysesService = analysesService;
        }

        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<IEnumerable<ZabotaAnalysesTypes>>> GetAnalysesTypesWithTests()
        {
            return await _analysesService.GetAnalysesTypesWithTests();
        }

        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<IEnumerable<ZabotaAnalysesTypes>>> GetAnalysesTypesWithoutTests()
        {
            return await _analysesService.GetAnalysesTypesWithoutTests();
        }

        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<ZabotaAnalysesTypes>> GetAnalysesType(int id)
        {
            return await _analysesService.GetAnalysesTypeById(id);
        }

        [ValidModelState]
        [HttpPost(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<bool>> AddAnalysesType([FromBody] NewAnalysesTypeForm form)
        {
            return await _analysesService.AddNewAnalysesType(new zabotalaboratory.Analyses.Forms.AnalysesTypes.NewAnalysesTypeForm
            {
                Name = form.Name,
                Number1C = form.Number1C
            });
        }

        [ValidModelState]
        [HttpPost(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<bool>> UpdateAnalysesType([FromBody] UpdateAnalysesTypeForm form)
        {
            return await _analysesService.UpdateAnalysesType(new zabotalaboratory.Analyses.Forms.AnalysesTypes.UpdateAnalysesTypeForm
            {
                Id = form.Id,
                Name = form.Name,
                Number1C = form.Number1C
            });
        }

        [ValidModelState]
        [HttpPost(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<bool>> UpdateAnalysesTypeValid([FromBody] UpdateAnalysesTypeValidForm form)
        {
            return await _analysesService.UpdateAnalysesTypeValid(new zabotalaboratory.Analyses.Forms.AnalysesTypes.UpdateAnalysesTypeValidForm
            {
                Id = form.Id,
                IsValid = form.IsValid
            });
        }
    }
}