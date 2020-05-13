using zabotalaboratory.Auth.Datamodel.Tokens;

namespace zabotalaboratory.Common.PasswordService.JwtGenerate
{
    public interface IJwtGenerator
    {
        Jwt Generate(Jwt source);
    }
}