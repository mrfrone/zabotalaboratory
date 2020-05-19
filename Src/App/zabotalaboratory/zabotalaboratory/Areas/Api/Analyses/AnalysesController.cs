using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zabotalaboratory.Analyses.Datamodel.Analyses;
using zabotalaboratory.Analyses.Datamodel.LaboratoryAnalyses;
using zabotalaboratory.Analyses.Services.Analyses;
using zabotalaboratory.Analyses.Services.LaboratoryAnalyses;
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
        private readonly ILaboratoryAnalysesService _laboratoryAnalysesService;
        private readonly IAnalysesService _analysesService;

        public AnalysesController(ILaboratoryAnalysesService laboratoryAnalysesService, IAnalysesService analysesService)
        {
            _analysesService = analysesService;
            _laboratoryAnalysesService = laboratoryAnalysesService;
        }
                
        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<IEnumerable<ZabotaLaboratoryAnalyses>>> LaboratoryAnalyses()
        {
            return await _laboratoryAnalysesService.GetLaboratoryAnalyses();
        }

        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<ZabotaLaboratoryAnalyses>> LaboratoryAnalyseById(int id)
        {
            return await _laboratoryAnalysesService.GetLaboratoryAnalyseById(id);
        }

        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<IEnumerable<ZabotaAnalysesTypes>>> AnalysesTypes()
        {
            return await _analysesService.GetAnalysesWithTests();
        }

        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<ZabotaAnalysesTypes>> AnalysesTypeById(int id)
        {
            return await _analysesService.GetAnalysesTypeById(id);                     
        }
    }
}