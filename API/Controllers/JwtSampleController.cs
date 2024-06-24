using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JwtSampleController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public JwtSampleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var msg = "just a test";

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Login()
        {
            User user = new() { Email = "test@test.com.br", Id = 1234 };

            var token = new Token(_configuration);

            var generatedToken = token.GenerateToken(user);

            return Ok(generatedToken);
        }
    }
}
