using System.Collections.Generic;
using System.Security.Policy;
using System;
using System.Linq;
using System.Collections.ObjectModel;

namespace PasswordValidatorApi.Models
{
    public class ValidationErrors
    {
        private static readonly ValidationErrors NONE = new ValidationErrors();

        private readonly List<string> errorMessages;

        private ValidationErrors() : this(new List<string>(0))
        {

        }

        private ValidationErrors(List<string> errorMessages)
        {
            this.errorMessages = errorMessages != null ? new List<string>(errorMessages) : new List<string>(0);
        }

        public static ValidationErrors None()
        {
            return NONE;
        }

        public static ValidationErrors Of(params string[] messages)
        {
            return new ValidationErrors(messages.ToList());
        }

        public static ValidationErrors Of(List<String> messages)
        {
            return new ValidationErrors(messages);
        }

        public bool HasErrors()
        {
            return errorMessages.Count() != 0;
        }

        public ReadOnlyCollection<String> GetErrorMessages()
        {
            return new ReadOnlyCollection<string>(errorMessages);
        }
    }
}
