using System.Text.RegularExpressions;

namespace PasswordValidatorApi.Models.ValidatorRules
{
    public class ContainsAtLeastOneUppercaseRule : IPasswordRule
    {
        private readonly string error_message = "Lowercase character and digits only";
        private readonly Regex regex = new Regex("[A-Z]+");

        public ValidationErrors Validate(string item)
        {
            Match match = regex.Match(item);

            if (!match.Success)
            {
                return ValidationErrors.Of(error_message);
            }

            return ValidationErrors.None();
        }
    }
}
