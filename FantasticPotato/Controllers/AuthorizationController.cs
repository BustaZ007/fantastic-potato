using System;
using System.Text.RegularExpressions;
using FantasticPotato.DB.Repository;
using FantasticPotato.Models;
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
        public IActionResult Authorization([FromBody]UserModel userv)
        {
            Console.WriteLine(userv.Login);
            Console.WriteLine(userv.Password);
            if (_userModelRepository.GetByLogin(userv.Login) == null)
            {
                Console.WriteLine("Not found");
                return BadRequest();
            }

            var user = _userModelRepository.GetByLogin(userv.Login);
            Console.WriteLine(user.Login);
            Console.WriteLine(user.Password);
            if (user.Password != userv.Password)
            {
                Console.WriteLine("Error pass");
                Console.WriteLine(user.Password);
                return BadRequest();
            }
            return Ok();
        }

    }
}
