using FantasticPotato.DB.Repository;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FantasticPotato.Controllers
{
    public class UserController : Controller
    {
        private readonly UserModelRepository _userModelRepository;

        public UserController(UserModelRepository UMR)
        {
            _userModelRepository = UMR;
        }

        [Authorize]
        [HttpGet("User/GetUser/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = _userModelRepository.GetById(id);
            return Ok(user);
        }

        public async Task<IActionResult> Login()
        {
            return Ok("No login");
        }
    }
}