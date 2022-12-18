using System;
using PasswordValidatorApi.Models;
using Xunit;

namespace PasswordValidatorApiTest
{

    //integration test
    public class PasswordValidatorUnitTest
    {
        [Theory]
        [InlineData("ABCdE")]
        [InlineData("aBCdE")]
        [InlineData("aBCde")]
        [InlineData("abcde")]
        public void ContainsLower_HaveLowercaseLetter_ReturnsTrue(string value)
        {
            IPasswordValidator validator = new PasswordValidator();

            var result = validator.ContainsLower(value);

            Assert.True(result);
        }

        [Theory]
        [InlineData("ABCDE")]
        [InlineData("12345")]
        [InlineData("ABC123")]
        public void ContainsLower_NotHaveLowercaseLetter_ReturnsFalse(string value)
        {
            IPasswordValidator validator = new PasswordValidator();

            var result = validator.ContainsLower(value);

            Assert.False(result);
        }

        [Theory]
        [InlineData("ABCdE")]
        [InlineData("aBCdE")]
        [InlineData("aBCde")]
        public void ContainsUpper_HaveUppercaseLetter_ReturnsTrue(string value)
        {
            IPasswordValidator validator = new PasswordValidator();

            var result = validator.ContainsUpper(value);

            Assert.True(result);
        }

        [Theory]
        [InlineData("abcde")]
        [InlineData("12345")]
        [InlineData("abc123")]
        public void ContainsUpper_NotHaveUppercaseLetter_ReturnsFalse(string value)
        {
            IPasswordValidator validator = new PasswordValidator();

            var result = validator.ContainsUpper(value);

            Assert.False(result);
        }

        [Theory]
        [InlineData("BACCa1")]
        [InlineData("BAC1Ca1")]
        public void ContainsDigit_HasNumericalDigits_ReturnsTrue(string value)
        {
            IPasswordValidator validator = new PasswordValidator();

            var result = validator.ContainsDigit(value);

            Assert.True(result);
        }

        [Theory]
        [InlineData("BACCa")]
        [InlineData("aBACa")]
        public void ContainsDigit_NotHaveNumericalDigits_ReturnsFalse(string value)
        {
            IPasswordValidator validator = new PasswordValidator();

            var result = validator.ContainsDigit(value);

            Assert.False(result);
        }

        [Theory]
        [InlineData(1, 5, "AA1cc")]
        [InlineData(1, 7, "AAA1ccc")]
        [InlineData(1, 10, "AAAA11cccc")]
        public void IsInLength_StringInLength_ReturnsTrue(int min, int max, string value)
        {
            IPasswordValidator validator = new PasswordValidator() {
                RequiredLengthMin = min,
                RequiredLengthMax = max
            };

            var result = validator.IsInLength(value);

            Assert.True(result);
        }

        [Theory]
        [InlineData(0, 0, "1")]
        [InlineData(1, 10, "")]
        [InlineData(-1, -1, "")]
        [InlineData(-1, -1, "CC1")]
        [InlineData(int.MaxValue, int.MaxValue, "")]
        [InlineData(int.MinValue, int.MinValue, "AAcc1")]
        public void IsInLength_StringNotInLength_ReturnsFalse(int min, int max, string value)
        {
            IPasswordValidator validator = new PasswordValidator()
            {
                RequiredLengthMin = min,
                RequiredLengthMax = max
            };

            var result = validator.IsInLength(value);

            Assert.False(result);
        }

        [Theory]
        [InlineData("ABCABC")]
        [InlineData("AAAAAAAA")]
        [InlineData("11111111")]
        [InlineData("abcdabcd")]
        [InlineData("abcabc")]
        [InlineData("123123")]
        [InlineData("abc123abc123abc")]
        public void IsImmediatelyFollowedBySameSequence_FollowedBySameSequence_ReturnsFalse(string value)
        {
            PasswordValidator validator = new PasswordValidator();

            var result = validator.IsImmediatelyFollowedBySameSequence(value);

            Assert.False(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData("AAAA11cccc")]
        [InlineData("AAaa11BBbb22")]
        [InlineData("AA11aaBB22bb")]
        public void IsImmediatelyFollowedBySameSequence_NotFollowedBySameSequence_ReturnsTrue(string value)
        {
            PasswordValidator validator = new PasswordValidator();

            var result = validator.IsImmediatelyFollowedBySameSequence(value);

            Assert.True(result);
        }

        [Theory]
        [InlineData("ABC1-2")]
        [InlineData("ab@!x3")]
        [InlineData("!@#$%^&*()_+|~}{\":?><")]
        public void ContainsNonLetterOrDigit_HaveNonLetterOrDigit_ReturnsTrue(string value)
        {
            PasswordValidator validator = new PasswordValidator();

            var result = validator.IsImmediatelyFollowedBySameSequence(value);

            Assert.True(result);
        }

        [Theory]
        [InlineData("ABCABC")]
        [InlineData("abcabc")]
        [InlineData("123123")]
        [InlineData("abc123abc123abc")]
        public void ContainsNonLetterOrDigit_NotHaveNonLetterOrDigit_ReturnsFalse(string value)
        {
            PasswordValidator validator = new PasswordValidator();

            var result = validator.IsImmediatelyFollowedBySameSequence(value);

            Assert.False(result);
        }


    }
}
