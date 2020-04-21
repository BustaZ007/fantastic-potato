using System.Diagnostics;
using FantasticPotato.DB.Repository;
using FantasticPotato.Models;
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

        [HttpGet("{id}")]
        public UserModel GetUser(int id)
        {
            var user = _userModelRepository.GetById(id);
            return user;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}