using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using zabotalaboratory.Api.Identities.Forms;
using zabotalaboratory.Auth.Datamodel.Identities;
using zabotalaboratory.Auth.Datamodel.Roles;
using zabotalaboratory.Auth.Services.Identities;
using zabotalaboratory.Common;
using zabotalaboratory.Common.Consts;
using zabotalaboratory.Common.Result;
using zabotalaboratory.Web.Common.Filters;

namespace zabotalaboratory.Web.Areas.Api.UsersProfiles
{
    [Authorize]
    [Area(AreaNames.Api)]
    [Route(HttpRouteConsts.DefaultController)]
    public class IdentitiesController : BaseController
    {
        private readonly IIdentityService _identityService;

        public IdentitiesController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [Authorize]
        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<IEnumerable<ZabotaIdentity>>> GetIdentities()
        {
            return await _identityService.GetIdentities();
        }

        [Authorize]
        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<ZabotaIdentity>> GetIdentityById(int id)
        {
            return await _identityService.GetIdentityById(id);
        }

        [Authorize]
        [ValidModelState]
        [HttpPost(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<bool>> AddIdentity([FromBody] AddIdentityForm form)
        {
            return await _identityService.AddIdentity(new zabotalaboratory.Auth.Forms.Identity.AddIdentityForm {
                Login = form.Login,
                Password = form.Password,
                RoleId = form.RoleId,
                SubRoleId = form.SubRoleId
            });
        }

        [Authorize]
        [ValidModelState]
        [HttpPost(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<bool>> UpdateIdentity([FromBody] UpdateIdentityForm form)
        {
            return await _identityService.UpdateIdentity(new zabotalaboratory.Auth.Forms.Identity.UpdateIdentityForm
            {
                Id = form.Id,
                Login = form.Login,
                Password = form.Password,
                ChangePassword = form.ChangePassword,
                RoleId = form.RoleId,
                SubRoleId = form.SubRoleId
            });
        }

        [Authorize]
        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<bool>> DeleteIdentityById(int id)
        {
            return await _identityService.DeleteIdentity(id, CurrentIdentity.Id);
        }

        [Authorize]
        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<IEnumerable<ZabotaRoles>>> GetRoles()
        {
            return await _identityService.GetRoles();
        }

        [Authorize]
        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<IEnumerable<ZabotaSubRoles>>> GetOnlyValidSubRoles()
        {
            return await _identityService.GetSubRoles(true);
        }

        [Authorize]
        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<IEnumerable<ZabotaSubRoles>>> GetSubRoles()
        {
            return await _identityService.GetSubRoles(false);
        }

        [Authorize]
        [HttpGet(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<ZabotaSubRoles>> GetSubRoleById(int id)
        {
            return await _identityService.GetSubRoleById(id);
        }

        [Authorize]
        [ValidModelState]
        [HttpPost(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<bool>> AddSubRole([FromBody] AddNewSubRoleForm form)
        {
            return await _identityService.AddSubRole(new zabotalaboratory.Auth.Forms.Roles.AddNewSubRoleForm
            {
                Name = form.Name
            });
        }

        [Authorize]
        [ValidModelState]
        [HttpPost(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<bool>> UpdateSubRole([FromBody] UpdateSubRoleForm form)
        {
            return await _identityService.UpdateSubRole(new zabotalaboratory.Auth.Forms.Roles.UpdateSubRoleForm
            {
                Id = form.Id,
                Name = form.Name
            });
        }

        [Authorize]
        [ValidModelState]
        [HttpPost(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<bool>> UpdateSubRoleValid([FromBody] UpdateSubRoleValidForm form)
        {
            return await _identityService.UpdateSubRoleValid(new zabotalaboratory.Auth.Forms.Roles.UpdateSubRoleValidForm
            {
                Id = form.Id,
                IsValid = form.IsValid
            });
        }
    }
}