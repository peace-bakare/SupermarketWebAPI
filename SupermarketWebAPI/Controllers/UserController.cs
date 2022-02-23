using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupermarketWebAPI.Domain.Models;
using System.Linq;
using System.Security.Claims;

namespace SupermarketWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("Admins")]
        [Authorize]
        public IActionResult AdminEndpoint()
        {
            var currentUSer = GetCurrentUser();

            return Ok($"Hi { currentUSer.GivenName}, You are an {currentUSer.Role}.");
        }

        [HttpGet("Public")]
        public IActionResult Public()
        {
            return Ok();
        }

        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new UserModel
                {
                    Username = userClaims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier)?.Value,
                    EmailAddress = userClaims.FirstOrDefault(p => p.Type == ClaimTypes.Email)?.Value,
                    Surname = userClaims.FirstOrDefault(p => p.Type == ClaimTypes.Surname)?.Value,
                    GivenName = userClaims.FirstOrDefault(p => p.Type == ClaimTypes.GivenName)?.Value,
                    Role = userClaims.FirstOrDefault(p => p.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }
    }
}
