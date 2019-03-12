using FluentValidation.Results;
using SimonGilbert.Blog.Sms.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimonGilbert.Blog.Sms.Validation
{
    public static class ValidationService
    {
        public static List<string> Validate(out bool isValid, SmsMessage model)
        {
            var validator = new SendSmsMessageValidator();

            var validationResult = validator.Validate(model);

            isValid = validationResult.IsValid;

            return AggregateErrors(validationResult);
        }

        private static List<string> AggregateErrors(ValidationResult validationResult)
        {
            var errors = new List<string>();

            if (!validationResult.IsValid)
            {
                Parallel.ForEach(validationResult.Errors, error =>
                {
                    errors.Add(error.ErrorMessage);
                });
            }

            return errors;
        }
    }
}