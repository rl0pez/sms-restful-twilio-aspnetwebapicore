using System.Threading.Tasks;
using SimonGilbert.Blog.Sms.Models;
using Twilio.Rest.Api.V2010.Account;

namespace SimonGilbert.Blog.Sms.Services
{
    public interface ISmsService
    {
        Task<MessageResource> Send(SmsMessage smsMessage);
    }
}