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
    [Authorize(Roles = Roles.Admin + ", " + Roles.Laborant + ", " + Roles.Clinic)]
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
            return await _analysesService.GetAnalysesTypes(true);
        }

        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<IEnumerable<ZabotaAnalysesTypes>>> GetAnalysesTypesWithoutTests()
        {
            return await _analysesService.GetAnalysesTypes(false);
        }

        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<IEnumerable<ZabotaAnalysesTypesAddForm>>> GetAnalysesTypesToAddForm()
        {
            return await _analysesService.GetAnalysesTypesToAddForm();
        }

        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<ZabotaAnalysesTypes>> GetAnalysesType(int id)
        {
            return await _analysesService.GetAnalysesTypeById(id);
        }

        [Authorize(Roles = Roles.Admin + ", " + Roles.Laborant)]
        [ValidModelState]
        [HttpPost(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<bool>> AddAnalysesType([FromBody] NewAnalysesTypeForm form)
        {
            return await _analysesService.AddNewAnalysesType(new Analyses.Forms.AnalysesTypes.NewAnalysesTypeForm
            {
                Name = form.Name,
                ExcelName = form.ExcelName,
                PDFName = form.PDFName,
                Number1C = form.Number1C,
                BioMaterial = form.BioMaterial
            });
        }

        [Authorize(Roles = Roles.Admin + ", " + Roles.Laborant)]
        [ValidModelState]
        [HttpPost(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<bool>> UpdateAnalysesType([FromBody] UpdateAnalysesTypeForm form)
        {
            return await _analysesService.UpdateAnalysesType(new Analyses.Forms.AnalysesTypes.UpdateAnalysesTypeForm
            {
                Id = form.Id,
                Name = form.Name,
                ExcelName = form.ExcelName,
                PDFName = form.PDFName,
                Number1C = form.Number1C,
                BioMaterial = form.BioMaterial
            });
        }

        [Authorize(Roles = Roles.Admin + ", " + Roles.Laborant)]
        [ValidModelState]
        [HttpPost(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<bool>> UpdateAnalysesTypeValid([FromBody] UpdateAnalysesTypeValidForm form)
        {
            return await _analysesService.UpdateAnalysesTypeValid(new Analyses.Forms.AnalysesTypes.UpdateAnalysesTypeValidForm
            {
                Id = form.Id,
                IsValid = form.IsValid
            });
        }

        [ValidModelState]
        [HttpPost(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<bool>> UpdateAnalysesTypeNumber([FromBody] UpdateTypesNumberInOrderForm form)
        {
            return await _analysesService.UpdateAnalysesTypeNumber(new Analyses.Forms.AnalysesTypes.UpdateTypesNumberInOrderForm
            {
                NumberInOrder = form.NumberInOrder,
                IsUp = form.IsUp
            });
        }
    }
}