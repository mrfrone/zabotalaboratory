using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zabotalaboratory.Analyses.Datamodel.LaboratoryAnalyses;
using zabotalaboratory.Analyses.Services.AnalysesService;
using zabotalaboratory.Common;
using zabotalaboratory.Common.Consts;
using zabotalaboratory.Common.Result;

namespace zabotalaboratory.Areas.Api.Auth
{
    [Authorize]
    [Area(AreaNames.Api)]
    [Route(HttpRouteConsts.DefaultController)]
    public class AnalysesController : BaseController
    {
        private readonly IAnalysesService _analysesService;

        public AnalysesController(IAnalysesService analysesService)
        {
            _analysesService = analysesService;
        }
                
        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<IEnumerable<ZabotaLaboratoryAnalyses>>> LaboratoryAnalyses()
        {
            return await _analysesService.GetLaboratoryAnalyses();
        }

        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<ZabotaLaboratoryAnalyses>> LaboratoryAnalyseById(int id)
        {
            var result = await _analysesService.GetLaboratoryAnalyseById(id);

            return result;
        }
    }
}