using System;
namespace PasswordValidatorBuilderApi.Models
{
    public class PasswordValidatorBuilder
    {

        public PasswordValidatorBuilder Is()
        {
            return this;
        }

        public PasswordValidatorBuilder Has()
        {
            return this;
        }

        public PasswordValidatorBuilder Not()
        {
            return this;
        }

        public PasswordValidatorBuilder Min(int num)
        {
            return this;
        }

        public PasswordValidatorBuilder Max(int num)
        {
            return this;
        }

        public PasswordValidatorBuilder Uppercase()
        {
            return this;
        }

        public PasswordValidatorBuilder LowerCase()
        {
            return this;
        }

        public PasswordValidatorBuilder Digits()
        {
            return this;
        }

        public bool Validate(string password)
        {
            return false;
        }

        public PasswordValidatorBuilder ContinuousSameSequence(bool symbol)
        {
            throw new NotImplementedException();
        }
    }
}
