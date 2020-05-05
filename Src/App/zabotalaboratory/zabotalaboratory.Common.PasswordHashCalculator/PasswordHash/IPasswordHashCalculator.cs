namespace zabotalaboratory.Common.PasswordService.PasswordHash
{
    public interface IPasswordHashCalculator
    {
        string Calc(string src);
    }
}
