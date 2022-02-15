
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SupermarketWebAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketWebAPI.Controllers
{
    public class LoginController : Controller
    {
        private IConfiguration _configuration;

        public LoginController (IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]                                                                                                                                                                                                                                                                                                                                      
        [HttpPost]
        public IActionResult Login ([FromBody]UserModel login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;
        }

        private string GenerateJSONWebToken(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.EmailAddress),
                new Claim("DateOfJoining", userInfo.DateOfJoining.ToString()), //"yyyy-MM-dd"
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel AuthenticateUser(UserModel login)
        {
            UserModel user = null;

            if (login.Username == "Jignesh")
            {
                user = new UserModel { Username = "Peace Bakare", EmailAddress = "peeace.bakare@gmail.com" };
            }
            return user;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var currentUser = HttpContext.User;
            int spendingTimeWithCompany = 0;

            if(currentUser.HasClaim(c => c.Type == "DateOfJoining"))
            {
                DateTime date = DateTime.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "DateOfJoining").Value);
                spendingTimeWithCompany = DateTime.Today.Year - date.Year;
            }

            if(spendingTimeWithCompany > 5)
            {
                return new string[] { "High Time1", "High Time2", "High Time3", "High Time4", "High Time5" };
            }
            else
            {
                return new string[] { "value1", "value2", "value3", "value4", "value5" };
            }
        }
    }
}
