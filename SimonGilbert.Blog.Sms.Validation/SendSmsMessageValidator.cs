﻿using System;
using FluentValidation;
using SimonGilbert.Blog.Sms.Models;

namespace SimonGilbert.Blog.Sms.Validation
{
    public class SendSmsMessageValidator : AbstractValidator<SmsMessage>
    {
        public SendSmsMessageValidator()
        {
            RuleFor(m => m.NumberFrom)
                .Must(BeAValidUKMobilePhoneNumber)
                .WithMessage("Please specify a valid UK mobile phone number to send the SMS from.");

            RuleFor(m => m.NumberTo)
                .Must(BeAValidUKMobilePhoneNumber)
                .WithMessage("Please specify a valid UK mobile phone number to send the SMS to.");

            RuleFor(m => m.Greeting).NotNull().WithMessage("Please specify the SMS greeting.");

            RuleFor(m => m.NameTo).NotNull().WithMessage("Please specify the receivers name.");

            RuleFor(m => m.Body).NotNull().WithMessage("Please specify the SMS message body.");

            RuleFor(m => m.Signature).NotNull().WithMessage("Please specify the SMS signature.");
        }

        private bool BeAValidUKMobilePhoneNumber(string mobilePhoneNumber)
        {
            if (!String.IsNullOrEmpty(mobilePhoneNumber) &&
                mobilePhoneNumber.StartsWith("+44", StringComparison.CurrentCulture) &&
                mobilePhoneNumber.Length == 13)
                return true;

            return false;
        }
    }
}