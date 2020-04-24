using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using FantasticPotato.DB.Repository;
using FantasticPotato.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FantasticPotato.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly UserModelRepository _userModelRepository;
        private readonly ILogger<AuthorizationController> _logger;

        public RegistrationController(ILogger<AuthorizationController> logger, UserModelRepository UMR)
        {
            _logger = logger;
            _userModelRepository = UMR;
        }

        [HttpPost]
        public IActionResult UserRegistration(UserModel user)
        {
            if (string.IsNullOrEmpty(user.Login))
            {
                return BadRequest("Login can't be empty");
            }
            else if (string.IsNullOrEmpty(user.Password))
            {
                return BadRequest("Password can't be empty");
            }
            else if (string.IsNullOrEmpty(user.Mail))
            {
                return BadRequest("Email can't be empty");
            }

            IPHostEntry heserver = Dns.GetHostEntry(Dns.GetHostName());
            var ip = heserver.AddressList[2].ToString();
            var userAgent = HttpContext.Request.Headers["User-Agent"].ToString();


            if (!string.IsNullOrEmpty(_userModelRepository.GetByLogin(user.Login).Login))
            {
                _logger.LogWarning("[AuthorizationController.Authorization] " + "\n Remote ip : " + ip +
                                   "\n User-agent : " + userAgent +
                                   "\n Login: " + user.Login +
                                   "\n Non unique LOGIN!");
                return BadRequest("This login is busy, use another");
            }

            if (!string.IsNullOrEmpty(_userModelRepository.GetByEmail(user.Mail).Mail))
            {
                _logger.LogWarning("[AuthorizationController.Authorization] " + "\n Remote ip : " + ip +
                                   "\n User-agent : " + userAgent +
                                   "\n Login: " + user.Login +
                                   "\n EMail: " + user.Mail +
                                   "\n Non unique Email address!");
                return BadRequest("Email should be unique");
            }


            if (user.DOB > DateTime.Now)
            {
                _logger.LogWarning("[AuthorizationController.Authorization] " + "\n Remote ip : " + ip +
                                   "\n User-agent : " + userAgent +
                                   "\n Login: " + user.Login +
                                   "\n Can't be future date ");
                return BadRequest("Date of birth problem");
            }


            if (Regex.IsMatch(user.Login, @"[^\w\.@-\\%]"))
            {
                _logger.LogWarning("[AuthorizationController.Authorization] " + "\n Remote ip : " + ip +
                                   "\n User-agent : " + userAgent +
                                   "\n Login: " + user.Login +
                                   "\n Login can't contains server symbol");
                return BadRequest("Login can't contains service symbol");
            }

            SHA1 sha1Hash = SHA1.Create();
            byte[] sourceBytes = Encoding.UTF8.GetBytes(user.Password);
            byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
            string hashPass = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

            user.Password = hashPass;
            _userModelRepository.AddNew(user);

            _logger.LogInformation("[AuthorizationController.Authorization] " + "\n Remote ip : " + ip +
                                   "\n User-agent : " + userAgent +
                                   "\n Login: " + user.Login +
                                   "\n Email: " + user.Mail +
                                   "\n Date of Birth: " + user.DOB +
                                   "\n New User was adding!");
            return Ok();
        }
    }
}