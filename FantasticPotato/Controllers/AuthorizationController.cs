using System;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using FantasticPotato.DB.Repository;
using FantasticPotato.Models;
using FantasticPotato.Models.DBModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace FantasticPotato.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly UserModelRepository _userModelRepository;
        private readonly ILogger<AuthorizationController> _logger;


        public AuthorizationController(ILogger<AuthorizationController> logger, UserModelRepository UMR)
        {
            _logger = logger;
            _userModelRepository = UMR;
        }

        [HttpPost]
        public  async Task<IActionResult> Authorization([FromBody] UserModel userv)
        {
            IPHostEntry heserver = Dns.GetHostEntry(Dns.GetHostName());
            var ip = heserver.AddressList[2].ToString();
            // var ip = "0.0.0.0";
            var userAgent = HttpContext.Request.Headers["User-Agent"].ToString();
            UserModel user;
            if (string.IsNullOrEmpty(userv.Login) || string.IsNullOrEmpty(userv.Password))
            {
                _logger.LogWarning("[AuthorizationController.Authorization] " + "\n Remote ip : " + ip +
                                   "\n User-agent : " + userAgent +
                                   "\n One of fields is empty");
                return Conflict("Fields required");
            }

            if (Regex.IsMatch(userv.Login, @"[^\w\.@-\\%]"))
            {
                if (_userModelRepository.GetByEmail(userv.Login) == null)
                {
                    _logger.LogWarning("[AuthorizationController.Authorization] " + "\n Remote ip : " + ip +
                                       "\n User-agent : " + userAgent +
                                       "\n EMail: " + userv.Login +
                                       "\n User not found by email");
                    return Content("User not found by email"!);
                }
                else
                    user = _userModelRepository.GetByEmail(userv.Login);
            }
            else
            {
                if (_userModelRepository.GetByLogin(userv.Login) == null)
                {
                    _logger.LogWarning("[AuthorizationController.Authorization] " + "\n Remote ip : " + ip +
                                       "\n User-agent : " + userAgent +
                                       "\n Login: " + userv.Login +
                                       "\n User not found by login");
                    return Content("User not found"!);
                }
                else
                    user = _userModelRepository.GetByLogin(userv.Login);
            }

            SHA1 sha1Hash = SHA1.Create();
            byte[] sourceBytes = Encoding.UTF8.GetBytes(userv.Password);
            byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
            string hashPass = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

            if (!user.Password.Equals(hashPass))
            {
                _logger.LogWarning("[AuthorizationController.Authorization] " + "\n Remote ip : " + ip +
                                   "\n User-agent : " + userAgent +
                                   "\n Login: " + userv.Login +
                                   "\n Password mismatch!");
                return Content("Password mismatch!");
            }

            _logger.LogInformation("[AuthorizationController.Authorization] " + "\n Remote ip : " + ip +
                                   "\n User-agent : " + userAgent +
                                   "\n Login: " + userv.Login +
                                   "\n Authorization was successful!");
            await Authenticate(user.Login);
            return Ok(user);
        }

        private async Task Authenticate(string login)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, login)
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync( CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            Console.WriteLine("кука сделана");
        }
    }
}
