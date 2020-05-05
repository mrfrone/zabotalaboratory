using System.Threading.Tasks;
using zabotalaboratory.Auth.Forms.Login;
using zabotalaboratory.Auth.Services.Login;
using zabotalaboratory.Web.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zabotalaboratory.Web.Common.Consts;

namespace zabotalaboratory.Web.Controllers.Auth
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
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginForm form)
        {
            var result = await _loginService.Login(new LoginForm
            {
                Login = form.Login,
                Password = form.Password
            });

            return ZabotaResult(result);
        }
        [HttpPost(HttpRouteConsts.DefaultAction)]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            var form = new LogoutForm
            {
                ActorId = CurrentIdentity.Id,
                TokenId = CurrentTokenId
            };
            var result = await _loginService.Logout(form);

            return ZabotaResult(result);
        }
    }
}