using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestApp2.DAL;
using TestApp2.Interfaces;
using TestApp2.Models;

namespace TestApp2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMainDbContext _context;

        public HomeController(ILogger<HomeController> logger, IMainDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //var users = _context.Users.ToList();
            //foreach(var user in users)
            //{
            //    _logger.LogInformation($"UserId {user.UserID}. UserName {user.Name}");
            //}
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}