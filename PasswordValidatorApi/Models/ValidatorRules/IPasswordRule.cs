namespace PasswordValidatorApi.Models.ValidatorRules
{
    public interface IPasswordRule
    {
        public ValidationErrors Validate(string item);

    }
}
