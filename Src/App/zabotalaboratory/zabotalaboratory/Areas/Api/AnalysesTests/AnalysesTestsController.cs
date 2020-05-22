using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zabotalaboratory.Analyses.Datamodel.Analyses;
using zabotalaboratory.Analyses.Services.Analyses;
using zabotalaboratory.Api.AnalysesTests.Forms;
using zabotalaboratory.Common;
using zabotalaboratory.Common.Consts;
using zabotalaboratory.Common.Result;
using zabotalaboratory.Web.Common.Filters;

namespace zabotalaboratory.Areas.Api.AnalysesTests
{
    [Authorize]
    [Area(AreaNames.Api)]
    [Route(HttpRouteConsts.DefaultController)]
    public class AnalysesTestsController : BaseController
    {
        private readonly IAnalysesService _analysesService;

        public AnalysesTestsController(IAnalysesService analysesService)
        {
            _analysesService = analysesService;
        }

        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<ZabotaLaboratoryAnalysesTests>> AnalysesTestById(int id)
        {
            return await _analysesService.GetAnalysesTestById(id);           
        }

        [ValidModelState]
        [HttpPost(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<bool>> AddAnalysesTest([FromBody] NewAnalysesTestForm form)
        {
            return await _analysesService.AddNewAnalysesTest(new zabotalaboratory.Analyses.Forms.AnalysesTests.NewAnalysesTestForm {
                Name = form.Name,
                Number1C = form.Number1C,
                AnalysesTypesId = form.AnalysesTypesId
            });
        }

        [ValidModelState]
        [HttpPost(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<bool>> UpdateAnalysesTest([FromBody] UpdateAnalysesTestForm form)
        {
            return await _analysesService.UpdateAnalysesTest(new zabotalaboratory.Analyses.Forms.AnalysesTests.UpdateAnalysesTestForm
            {
                Id = form.Id,
                Name = form.Name,
                Number1C = form.Number1C,
                AnalysesTypesId = form.AnalysesTypesId
            });
        }

        [ValidModelState]
        [HttpPost(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<bool>> UpdateAnalysesTestValid([FromBody] UpdateAnalysesTestValidForm form)
        {
            return await _analysesService.UpdateAnalysesTestValid(new zabotalaboratory.Analyses.Forms.AnalysesTests.UpdateAnalysesTestValidForm
            {
                Id = form.Id,
                IsValid = form.IsValid
            });
        }
    }
}