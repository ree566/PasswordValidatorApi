using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PasswordValidatorApi.Models
{
    public class PasswordValidator : IPasswordValidator
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

        public bool ContainsNonLetterOrDigit(string item)
        {
            Regex regex = new Regex("[a-zA-Z\\d]");
            return regex.Match(item).Success;
        }

        public bool ContainsUpper(string item)
        {
            Regex regex = new Regex("[A-Z]");
            return regex.Match(item).Success;
        }

        public bool ContainsLower(string item)
        {
            Regex regex = new Regex("[a-z]");
            return regex.Match(item).Success;
        }

        public bool ContainsDigit(string item)
        {
            Regex regex = new Regex("\\d");
            return regex.Match(item).Success;
        }

        public virtual bool IsInLength(string s)
        {
            return s.Length >= RequiredLengthMin && s.Length <= RequiredLengthMax;
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
            //Must not contain any repeating substrings of three characters or more
            Regex regex = new Regex("(...+)\\1");
            return !regex.Match(item).Success;
        }
    }
}
