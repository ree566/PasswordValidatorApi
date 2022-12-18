namespace PasswordValidatorApi.Models
{
    public interface IPasswordValidator : IBaseValidator
    {
        bool IsContinuousSameSequence(string item);
    }
}