namespace PasswordValidatorApi.Models
{
    public interface IPasswordValidator : IBaseValidator
    {
        bool IsImmediatelyFollowedBySameSequence(string item);
    }
}