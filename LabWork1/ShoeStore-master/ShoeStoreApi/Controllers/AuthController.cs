using DatabaseLibrary.Contexts;
using DatabaseLibrary.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoeStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService = new();
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<string>> LoginUser(string login, string password)
        {
            var token = await _authService.AuthUserAsync(login,password);
            if (token is null)
                return Forbid();
            return token;
        }
    }
}
