using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FantasticPotato.DB.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FantasticPotato.Models;

namespace FantasticPotato.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly UserModelRepository _userModelRepository;

        // public HomeController(ILogger<HomeController> logger)
        // {
        //     _logger = logger;
        // }
        public HomeController(UserModelRepository userModelRepository)
        {
            _userModelRepository = userModelRepository;
        }

        public IActionResult Index()
        {
            var users = _userModelRepository.GetAllUser;


            return View(users);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}