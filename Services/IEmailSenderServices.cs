using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using PAPELERIANGELESC.Models;
using System.Threading.Tasks;

namespace PAPELERIANGELESC.Services
{
    public interface IEmailSenderServices
    {
        [Microsoft.AspNetCore.Components.Route("api/[controller]")]
        [ApiController]
        public class MailController : ControllerBase
        {
            private readonly IMailService _mail;
            public MailController(IMailService mail)
            {
                _mail = mail;
            }
            [HttpPost("sendmail")]
            public async Task<IActionResult> SendMailAsync(MailRequestModel mailData)
            {
                bool result = await _mail.SendAsync(mailData, new CancellationToken());
                if (result)
                {
                    return StatusCode(StatusCodes.Status200OK, "Mail has successfully been sent.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occured. The Mail could not be sent.");
                }
            }
        }
    }
}