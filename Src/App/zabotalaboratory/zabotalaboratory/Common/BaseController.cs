using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using zabotalaboratory.Auth.Datamodel.Identities;
using zabotalaboratory.Common.Storage;

namespace zabotalaboratory.Common
{
    public class BaseController : Controller
    {
        protected int CurrentTokenId
        {
            get
            {
                var tokenIdClaim = HttpContext.User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier);
                int.TryParse(tokenIdClaim.Value, out int tokenId);

                return tokenId;
            }
        }

        protected ZabotaIdentity CurrentIdentity
        {
            get
            {
                var service = HttpContext.RequestServices.GetService<IIdentityRequestStorage>();
                return service.Current;
            }
        }

        //protected IActionResult ZabotaResult<T>(T result)
        //{
        //    return Json(new ZabotaResult<T>(result));
        //}

        //protected IActionResult ZabotaResult<T>(ZabotaResult<T> result)
        //{
        //    return Json(result);
        //}

        //protected IActionResult ZabotaResult(ZabotaResult result)
        //{
        //    return Json(result);
        //}

        //protected IActionResult ZabotaError(ZabotaErrorCodes code, string message = null)
        //{
        //    return Json(new ZabotaResult(zabotalaboratory.Common.Result.ZabotaError.FromCode(code, message)));
        //}

        //protected IActionResult ZabotaError(ZabotaError error)
        //{
        //    return Json(new ZabotaResult(error));
        //}
    }
}