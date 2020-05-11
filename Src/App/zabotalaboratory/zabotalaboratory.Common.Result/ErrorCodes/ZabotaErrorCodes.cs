namespace zabotalaboratory.Common.Result.ErrorCodes
{
    public enum ZabotaErrorCodes
    {
        Ok = 1000000,
        InvalidForm = 1000001,
        AuthorizeError = 1000002,
        CreateTokenError = 1000003,
        CannotFindToken = 1000004,
        CannotFindIdentityByTokenId = 1000005,
        CannotFindUserProfileByIdentityId = 1000006,
        EmptyResult = 1000007
    }

    public static class ErrorCodesExtensions
    {
        public static bool IsCorrect(this ZabotaErrorCodes code)
        {
            return code == ZabotaErrorCodes.Ok;
        }

        public static bool IsNotCorrect(this ZabotaErrorCodes code)
        {
            return !code.IsCorrect();
        }

        public static ZabotaResult<T> ToErrorResult<T>(this ZabotaErrorCodes code)
        {
            return new ZabotaResult<T>(new ZabotaError {Code = code});
        }

        public static string ToFriendlyString(this ZabotaErrorCodes code)
        {
            switch (code)
            {
                default:
                    return code.ToString();
            }
        }
        
    }
}