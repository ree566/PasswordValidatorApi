using System;
namespace PasswordValidatorApi.Models
{
    public interface IBaseValidator
    {
        public bool IsInLength(string item);

        public bool ContainsNonLetterOrDigit(string item);

        public bool ContainsUpper(string item);

        public bool ContainsLower(string item);

        public bool ContainsDigit(string item);

        public bool Validate(string item);
    }
}
