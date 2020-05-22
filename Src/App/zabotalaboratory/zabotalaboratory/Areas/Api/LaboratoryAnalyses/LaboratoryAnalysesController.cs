using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zabotalaboratory.Analyses.Datamodel.LaboratoryAnalyses;
using zabotalaboratory.Analyses.Services.LaboratoryAnalyses;
using zabotalaboratory.Common;
using zabotalaboratory.Common.Consts;
using zabotalaboratory.Common.Result;

namespace zabotalaboratory.Areas.Api.LaboratoryAnalyses
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

        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<IEnumerable<ZabotaLaboratoryAnalyses>>> GetLaboratoryAnalyses()
        {
            return await _laboratoryAnalysesService.GetLaboratoryAnalyses();
        }

        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<ZabotaLaboratoryAnalyses>> LaboratoryAnalyseById(int id)
        {
            return await _laboratoryAnalysesService.GetLaboratoryAnalyseById(id);
        }

    }
}