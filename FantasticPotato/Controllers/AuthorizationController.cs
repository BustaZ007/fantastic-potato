using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using FantasticPotato.DB.Repository;
using FantasticPotato.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace FantasticPotato.Controllers
{
    public class AuthorizationController  : Controller
    {

        private readonly UserModelRepository _userModelRepository;

        public AuthorizationController()
        {
            _userModelRepository = new UserModelRepository();
        }

        [HttpPost]
        public async Task<IActionResult> Authorization([FromBody]UserModel userv)
        {
            var user = _userModelRepository.GetByLogin(userv.Login);
            if (_userModelRepository.GetByLogin(userv.Login) != null && user.Password == userv.Password)
            {
                await Authenticate(user);
                return Ok(user);
            }

            return Content("ErrorLogin");
        }

        private async Task Authenticate(UserModel user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
