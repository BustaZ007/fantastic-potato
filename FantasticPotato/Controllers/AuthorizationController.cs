using System;
using System.Text.RegularExpressions;
using FantasticPotato.DB.Repository;
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
        public IActionResult Authorization(string login, string pass)
        {
            if (_userModelRepository.GetByLogin(login) == null)
                return BadRequest();

            var user = _userModelRepository.GetByLogin(login);
            if (user.Password != pass)
            {
                return BadRequest();
            }
            return Ok();
        }
        
    }
}