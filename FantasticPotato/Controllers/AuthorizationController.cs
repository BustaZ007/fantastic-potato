using System;
using System.Text.RegularExpressions;
using FantasticPotato.DB.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FantasticPotato.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorizationController  : Controller
    {

        private readonly UserModelRepository _userModelRepository;

        public AuthorizationController()
        {
            _userModelRepository = new UserModelRepository();
        }

        [HttpPost]
        public IActionResult Authorization(string login, string password)
        {
            if (_userModelRepository.GetByLogin(login) == null)
                return BadRequest("Day jopu bliyat\'");

            var user = _userModelRepository.GetByLogin(login);
            if (user.Password != password)
            {
                return BadRequest();
            }
            return Ok();
        }

    }
}
