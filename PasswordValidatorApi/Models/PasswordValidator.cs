using System;
using System.Linq;

namespace PasswordValidatorApi.Models
{
    public class PasswordValidator : IPasswordValidator, CustomValidator
    {

        /// <summary>
        /// Mininum required length, default = 1
        /// </summary>
        public int RequiredLengthMin { get; set; } = 1;

        /// <summary>
        /// Maxinum required length, defalut = int.MaxValue
        /// </summary>
        public int RequiredLengthMax { get; set; } = int.MaxValue;

        /// <summary>
        /// Require non digit or non letter character, default = true
        /// </summary>
        public bool RequiredNonLetterOrDigit { get; set; } = true;

        /// <summary>
        /// Require a lowercase between 'a' - 'z', default = true
        /// </summary>
        public bool RequiredLowercase { get; set; } = true;

        /// <summary>
        /// Require a uppercase between 'A' - 'Z', default = false
        /// </summary>
        public bool RequiredUppercase { get; set; } = false;

        /// <summary>
        /// Require a digit between '0' - '9', default = true
        /// </summary>
        public bool RequiredDigit { get; set; } = true;

        public bool IsContinuousSameSequence(string item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsNonLetterOrDigit(string item)
        {
            return item.All(c => IsNonLetterOrDigit(c));
        }

        public bool ContainsUpper(string item)
        {
            return item.Any(c => IsUpper(c));
        }

        public bool ContainsLower(string item)
        {
            return item.Any(c => IsLower(c));
        }

        public bool ContainsDigit(string item)
        {
            return item.Any(c => IsDigit(c));
        }

        public virtual bool IsInLength(string s)
        {
            return s.Length >= RequiredLengthMin && s.Length <= RequiredLengthMax;
        }

        public virtual bool IsNonLetterOrDigit(char c)
        {
            return IsUpper(c) || IsLower(c) || IsDigit(c);
        }

        public virtual bool IsUpper(char c)
        {
            return c >= 'A' && c <= 'Z';
        }

        public virtual bool IsLower(char c)
        {
            return c >= 'a' && c <= 'z';
        }

        public virtual bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }

        public bool Validate(string item)
        {
            if (string.IsNullOrEmpty(item) || RequiredLengthMin > RequiredLengthMax || !IsInLength(item))
                return false;

            if (RequiredNonLetterOrDigit && !ContainsNonLetterOrDigit(item))
                return false;


            if (RequiredUppercase && !ContainsUpper(item))
                return false;


            if (RequiredLowercase && !ContainsLower(item))
                return false;

            if (RequiredDigit && !ContainsDigit(item))
                return false;

            return true;
        }

        public bool IsImmediatelyFollowedBySameSequence(string item)
        {
            throw new NotImplementedException();
        }
    }
}
