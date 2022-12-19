using System.Data;
using System.Text.RegularExpressions;

namespace PasswordValidatorApi.Models.ValidatorRules
{
    public class CharacterLengthFilterRule : IPasswordRule
    {

        private readonly string error_message = "Character length is invalid";

        public int LenMin { get; set; } = 1;
        
        public int LenMax { get; set; } = int.MaxValue;

        public CharacterLengthFilterRule()
        {

        }

        public CharacterLengthFilterRule(int min, int max)
        {
            LenMin = min;
            LenMax = max;
        }

        public ValidationErrors Validate(string item)
        {
            if (string.IsNullOrEmpty(item) || item.Length < LenMin || item.Length > LenMax)
            {
                return ValidationErrors.Of(error_message);
            }

            return ValidationErrors.None();
        }
    }
}
