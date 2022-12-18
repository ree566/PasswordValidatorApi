using System;
namespace PasswordValidatorApi.Models
{
    public class PasswordValidator
    {

        public PasswordValidator()
        {
        }

        public PasswordValidator Is()
        {
            return this;
        }

        public PasswordValidator Has()
        {
            return this;
        }

        public PasswordValidator Not()
        {
            return this;
        }

        public PasswordValidator Min(int num)
        {
            return this;
        }

        public PasswordValidator Max(int num)
        {
            return this;
        }

        public PasswordValidator Uppercase()
        {
            return this;
        }

        public PasswordValidator LowerCase()
        {
            return this;
        }

        public PasswordValidator Digits()
        {
            return this;
        }

        public bool Validate(string password)
        {
            return false;
        }

        public PasswordValidator ContinuousSameSequence(bool symbol)
        {
            throw new NotImplementedException();
        }
    }
}
