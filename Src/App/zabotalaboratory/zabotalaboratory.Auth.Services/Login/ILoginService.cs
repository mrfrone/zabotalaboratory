using System.Threading.Tasks;
using zabotalaboratory.Auth.Datamodel.Tokens;
using zabotalaboratory.Auth.Forms.Login;
using zabotalaboratory.Common.Result;

namespace zabotalaboratory.Auth.Services.Login
{
    public interface ILoginService
    {
        Task<ZabotaResult<Jwt>> Login(LoginForm form);
        Task<ZabotaResult<bool>> Logout(LogoutForm form);
    }
}
