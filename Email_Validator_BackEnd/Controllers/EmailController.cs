using Email_Validator_BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Email_Validator_BackEnd.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmailController : ControllerBase
{
    private readonly EmailValidatorService _service;

    public EmailController(EmailValidatorService service)
	{
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetChecked(string email)
    {
        var json = await _service.CheckEmailAsync(email);
        return Ok(json);
    }
}
