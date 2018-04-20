using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SampleCoreWebApi.BusinessEntities.EntityModels;
using SampleCoreWebApi.BusinessLayer.IRepositories;
using SampleCoreWebApi.RequestModels;

namespace SampleCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IVolunteerRepository _volunteerRepository;
        public TokenController(IConfiguration config, IVolunteerRepository volunteerRepository)
        {
            _config = config;
            _volunteerRepository = volunteerRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateToke([FromBody] LoginModel login)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                //if valid user then respond token else respond as unauthorized
                var userDetails = await _volunteerRepository.ValidateUser(login.MobileNumber, login.Password);
                if (userDetails == null)
                {
                    return Unauthorized();
                }

                var tokenString = BuildToken(new UserModel() { MobileNumber = userDetails.VolunteerMobileNumber, Name = userDetails.VolunteerName, UserId = userDetails.VolunteerId });
                return Ok(new { token = tokenString });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [NonAction]
        private string BuildToken(UserModel user)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sid, user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.MobileNumber),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddYears(60),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}