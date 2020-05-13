using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zabotalaboratory.Auth.Datamodel.Tokens;
using zabotalaboratory.Auth.Services.Login;
using zabotalaboratory.Common;
using zabotalaboratory.Common.Consts;
using zabotalaboratory.Common.Result;
using zabotalaboratory.Web.Common.Filters;

namespace zabotalaboratory.Areas.Api.Auth
{
    [Area(AreaNames.Api)]
    [Route(HttpRouteConsts.DefaultController)]
    public class AuthController : BaseController
    {
        private readonly ILoginService _loginService;

        public AuthController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost(HttpRouteConsts.DefaultAction)]
        [ValidModelState]
        public async Task<ZabotaResult<Jwt>> Login([FromBody]zabotalaboratory.Api.Auth.Forms.LoginForm form)
        {
            return await _loginService.Login(new zabotalaboratory.Auth.Forms.Login.LoginForm
            {
                Login = form.Login,
                Password = form.Password
            });
        }

        [Authorize]
        [HttpPost(HttpRouteConsts.DefaultAction)]
        public async Task<ZabotaResult<bool>> Logout()
        {
            var form = new zabotalaboratory.Auth.Forms.Login.LogoutForm
            {
                ActorId = CurrentIdentity.Id,
                TokenId = CurrentTokenId
            };
            return await _loginService.Logout(form);
        }
    }
}