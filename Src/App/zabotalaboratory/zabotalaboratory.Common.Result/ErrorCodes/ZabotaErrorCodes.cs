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
        EmptyResult = 1000007,
        IdentityExists = 1000008,
        CannotFindIdentityById = 1000009,
        UpdateIdentityOperationError = 1000010,
        CannotDeleteCurrentUser = 1000011,
        AddClinicOperationError = 1000012,
        UpdateClinicOperationError = 1000013,
        CannotFindClinicById = 1000014
        
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
            return new ZabotaResult<T>(new ZabotaError { Code = code });
        }

        public static string ToFriendlyString(this ZabotaErrorCodes code)
        {
            switch (code)
            {
                case(ZabotaErrorCodes.InvalidForm):
                    return "Отправленные данные не корректны";
                case (ZabotaErrorCodes.AuthorizeError):
                    return "Ошибка авторизации";
                case (ZabotaErrorCodes.CreateTokenError):
                    return "Ошибка при создании токена";
                case (ZabotaErrorCodes.CannotFindToken):
                    return "Не удается найти токен";
                case (ZabotaErrorCodes.CannotFindIdentityByTokenId):
                    return "Не удается найти пользователя по номеру токена";
                case (ZabotaErrorCodes.CannotFindUserProfileByIdentityId):
                    return "Не удалось найти профиль пользователя, пожалуйста, проверьте заполненность профиля";
                case (ZabotaErrorCodes.EmptyResult):
                    return "Данные не найдены";
                case (ZabotaErrorCodes.IdentityExists):
                    return "Такой пользователь уже существует";
                case (ZabotaErrorCodes.CannotFindIdentityById):
                    return "Не удается найти пользователя";
                case (ZabotaErrorCodes.UpdateIdentityOperationError):
                    return "Ошибка при обновлении информации о пользователе";
                case (ZabotaErrorCodes.CannotDeleteCurrentUser):
                    return "Невозможно удалить текущего пользователя";
                case (ZabotaErrorCodes.AddClinicOperationError):
                    return "Ошибка при добавлении новой поликлиники";
                case (ZabotaErrorCodes.UpdateClinicOperationError):
                    return "Ошибка при обновлении информации о поликлинике";
                case (ZabotaErrorCodes.CannotFindClinicById):
                    return "Не удается найти поликлинику";
                default:
                    return code.ToString();
            }
        }

    }
}