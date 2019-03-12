using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimonGilbert.Blog.Sms.Models;
using SimonGilbert.Blog.Sms.Services;
using SimonGilbert.Blog.Sms.Validation;

namespace SimonGilbert.Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly ISmsService _smsService;

        public MessageController(ISmsService smsService)
        {
            this._smsService = smsService;
        }

        // POST api/{controller}/send
        [HttpPost("send")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Send([FromBody]SmsMessage model)
        {
            var errors = ValidationService.Validate(out bool isValid, model);

            if (isValid)
            {
                var result = await _smsService.Send(model);

                return Ok(new GenericApiResponse(result));
            }
            else
            {
                return BadRequest(new GenericApiResponse(errors));
            }
        }
    }
}