using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;

namespace MultiShop.IdentityServer.Controllers
{
    [Authorize(IdentityServerConstants.LocalApi.PolicyName)]
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController(UserManager<ApplicationUser> userManager) : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(RegisterUserDto registerUser)
        {
            var user = new ApplicationUser
            {
                Name = registerUser.Name,
                Surname = registerUser.Surname,
                UserName = registerUser.Username,
                Email = registerUser.Email
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (result.Succeeded)
            {
                return Ok("Kullanıcı Başarıyla Oluşturuldu.");
            }

            return BadRequest("Kullanıcı Oluşturulamadı.");
        }
    }
}