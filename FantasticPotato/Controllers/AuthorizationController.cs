using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using FantasticPotato.DB.Repository;
using FantasticPotato.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Logging;

namespace FantasticPotato.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorizationController : Controller
    {
        private readonly UserModelRepository _userModelRepository;
        private readonly ILogger<AuthorizationController> _logger;


        public AuthorizationController( ILogger<AuthorizationController> logger )
        {
            _logger = logger;
            _userModelRepository = new UserModelRepository();
        }

        [HttpPost]
        public IActionResult Authorization([FromBody] UserModel userv)
        {
            IPHostEntry heserver = Dns.GetHostEntry(Dns.GetHostName());
            var ip = heserver.AddressList[2].ToString();
            var userAgent = HttpContext.Request.Headers["User-Agent"].ToString();
            Console.WriteLine("Remote ip : " + ip);
            Console.WriteLine("User-agent : " + userAgent);
            UserModel user;
            if (string.IsNullOrEmpty(userv.Login) || string.IsNullOrEmpty(userv.Password))
            {
                _logger.LogWarning("[AuthorizationController.Authorization] " + "\n Remote ip : " + ip +
                                   "\n User-agent : " + userAgent +
                                   "\n One of fields is empty");
                return Conflict("Fields required");
            }


            Console.WriteLine("userv: " + userv.Login);
            Console.WriteLine("userv: " + userv.Password);


            if (Regex.IsMatch(userv.Login, @"[^\w\.@-\\%]"))
            {
                Console.WriteLine("Service symbol");
                if (_userModelRepository.GetByEmail(userv.Login) == null)
                {
                    Console.WriteLine("Not found by email!");
                    _logger.LogWarning("[AuthorizationController.Authorization] " + "\n Remote ip : " + ip +
                                       "\n User-agent : " + userAgent +
                                       "\n EMail: " + userv.Login +
                                       "\n User not found by email");
                    return BadRequest("User not found by email"!);
                }
                else
                {
                    user = _userModelRepository.GetByEmail(userv.Login);
                }
            }
            else
            {
                if ( _userModelRepository.GetByLogin(userv.Login) == null)
                {
                    _logger.LogWarning("[AuthorizationController.Authorization] " + "\n Remote ip : " + ip +
                                       "\n User-agent : " + userAgent +
                                       "\n Login: " + userv.Login +
                                       "\n User not found by login");
                    Console.WriteLine("Not found!");
                    return BadRequest("User not found"!);
                }
                else
                {
                    user = _userModelRepository.GetByLogin(userv.Login);
                }
            }


            Console.WriteLine("user: " + user.Login);
            Console.WriteLine("user: " + user.Password);
            
            // Сделать проверку по хэшу пароля, клгда он будет добавлен в регистрацию ( так же поменять это в ЮзерМодели)
            if (!user.Password.Equals(userv.Password) )
            {
                _logger.LogWarning("[AuthorizationController.Authorization] " + "\n Remote ip : " + ip +
                                   "\n User-agent : " + userAgent +
                                   "\n Login: " + userv.Login +
                                   "\n Password mismatch!");
                Console.WriteLine("Error pass"!);
                Console.WriteLine(user.Password);
                return BadRequest("Password mismatch!");
            }

            _logger.LogInformation("[AuthorizationController.Authorization] " + "\n Remote ip : " + ip +
                                   "\n User-agent : " + userAgent +
                                   "\n Login: " + userv.Login +
                                   "\n Authorization was successful!");
            return Ok();
        }
    }
}