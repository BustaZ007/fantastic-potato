using System;
using System.Text.RegularExpressions;
using FantasticPotato.DB.Repository;
using FantasticPotato.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace FantasticPotato.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly UserModelRepository _userModelRepository;

        public RegistrationController()
        {
            _userModelRepository = new UserModelRepository();
        }

        [HttpPost]
        public IActionResult UserRegistration(UserModel user)
        {
            if (_userModelRepository.GetByEmail(user.Mail) != null)
            {
                return BadRequest("Email should be unique");
            }

            if (_userModelRepository.GetByLogin(user.Login) != null)
            {
                return BadRequest("This login is busy, use another");
            }
            if (user.DOB > DateTime.Now)
            {
                return BadRequest("Date of birth problem");
            }
            
            // var pattern=@"[@-.?!)(,:]";
            // var reg = new Regex(pattern);
            if(user.Login.Contains("@"))
            {
                return BadRequest("Login can't contains service symbol");
            }
            
            // Можно добавить валидацию по возрасту

            _userModelRepository.AddNew(user);
            return Ok();
        }
    }
}