using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using CourseEnrollment.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using StaffManagement.Api.Helpers;
using StaffManagement.Api.Services;

namespace StaffManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IConfiguration _configuration;

        public StaffController(IStaffService staffService, IConfiguration configuration)
        {
            _staffService = staffService;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Create([FromBody] StaffRegistration item)
        {
            var result = await _staffService.RegisterAsync(item);
            return Ok(result);
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login(string email, string pswd)
        {
            var result = await _staffService.LoginAsync(email,pswd);
            if (result)
            {
                // TODO: Validate accessCode

                List<Claim> claims = new List<Claim>() {
                    new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim (JwtRegisteredClaimNames.Email, "")
                };

                BearerTokenOptions bearerTokenOptions = AppSettingsHelper.RetrieveSection<AppSettings>(_configuration, "AppSettings").BearerTokenOptions;

                JwtSecurityToken token = new BearerTokenHelper()
                            .AddAudience(bearerTokenOptions.Audience)
                            .AddIssuer(bearerTokenOptions.Issuer)
                            .AddExpiry(bearerTokenOptions.ExpiryInMinutes)
                            .AddKey(bearerTokenOptions.AuthKey)
                            .AddClaims(claims)
                            .Build();

                IdentityModelEventSource.ShowPII = true;
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new { Token = tokenString, ExpiresIn = bearerTokenOptions.ExpiryInMinutes });
            }

            return BadRequest("Invalid credentials!!");
        }
    }
}
