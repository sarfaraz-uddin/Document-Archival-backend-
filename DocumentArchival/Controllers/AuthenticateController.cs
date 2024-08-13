using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentArchival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        public AuthenticateController() { }
        [HttpGet]
        [Route("login")]
        public async Task<ActionResult> Login()
        {

            return Ok();
        }
    }
}
