using System;
using System.Collections.Generic;
using System.Diagnostics;
using FantasticPotato.DB.Repository;
using FantasticPotato.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace FantasticPotato.Controllers
{
    public class UserController : Controller
    {
        private readonly UserModelRepository _userModelRepository;

        public UserController()
        {
            _userModelRepository = new UserModelRepository();
        }

        [Authorize]
        public UserModel GetUser([FromBody]string login)
        {
            var user = _userModelRepository.GetByLogin(login);
            Console.WriteLine(user.Login);
            return user;
        }
    }
}
