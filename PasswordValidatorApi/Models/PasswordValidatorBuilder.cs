using PasswordValidatorApi.Models.ValidatorRules;
using System;

namespace PasswordValidatorApi.Models
{
    public class PasswordValidatorBuilder : IPasswordValidatorBuilder
    {
        IValidatorRuleService _service;

        public PasswordValidatorBuilder()
        {
            _service = new ValidatorRuleServiceImpl();
        }

        public IPasswordValidatorBuilder WithRules(params IPasswordRule[] rule)
        {
            _service.AddRules(rule);
            return this;
        }

        public IPasswordValidator Build()
        {
            if (_service.GetRules().Count == 0)
            {
                throw new InvalidOperationException("Rules can't be empty!");
            }
            IPasswordValidator validator = new PasswordValidator(_service);
            return validator;
        }
    }
}
