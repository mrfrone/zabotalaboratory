using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zabotalaboratory.Analyses.Datamodel.Analyses;
using zabotalaboratory.Analyses.Services.Analyses;
//using zabotalaboratory.Api.AnalysesTypes.Forms;
using zabotalaboratory.Common;
using zabotalaboratory.Common.Consts;
using zabotalaboratory.Common.Result;
using zabotalaboratory.Web.Common.Filters;

namespace zabotalaboratory.Areas.Api.AnalysesTypes
{
    [Authorize]
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
        public async Task<ZabotaResult<IEnumerable<ZabotaAnalysesTypes>>> GetAnalysesTypes()
        {
            return await _analysesService.GetAnalysesTypesWithTests();
        }
    }
}