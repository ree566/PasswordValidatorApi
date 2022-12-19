using System.Text.RegularExpressions;

namespace PasswordValidatorApi.Models.ValidatorRules
{
    public class NotContainAdjacentSameSequenceRule : IPasswordRule
    {
        private readonly string error_message = "Adjacent same sequence not allowed";
        private readonly Regex regex = new Regex("(.+)\\1");

        public ValidationErrors Validate(string item)
        {
            Match match = regex.Match(item);

            if (match.Success)
            {
                return ValidationErrors.Of(error_message);
            }

            return ValidationErrors.None();
        }
    }
}
