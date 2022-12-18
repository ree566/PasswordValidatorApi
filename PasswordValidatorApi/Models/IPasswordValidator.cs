namespace PasswordValidatorApi.Models
{
    public interface IPasswordValidator
    {
        PasswordValidator Digits(int num);
        PasswordValidator Has();
        PasswordValidator Is();
        PasswordValidator LowerCase();
        PasswordValidator Max(int num);
        PasswordValidator Min(int num);
        PasswordValidator Not();
        PasswordValidator Uppercase();
        bool Validate(string password);
    }
}