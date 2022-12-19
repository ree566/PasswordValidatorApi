using System.Collections.Generic;

namespace PasswordValidatorApi.Models
{
    public class ValidationResult
    {
        public List<string> Messages { get; set; }

        public bool IsValid { get; set; }
    }
}
