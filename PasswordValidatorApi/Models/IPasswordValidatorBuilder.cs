using PasswordValidatorApi.Models.ValidatorRules;

namespace PasswordValidatorApi.Models
{
    public interface IPasswordValidatorBuilder
    {
        public IPasswordValidatorBuilder WithRules(params IPasswordRule[] rule);

        public IPasswordValidator Build();
    }
}
