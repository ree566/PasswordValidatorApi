namespace PasswordValidatorApi.Models
{
    public interface IPasswordValidator
    {
        ValidationResult ValidateRules(string item);
    }
}