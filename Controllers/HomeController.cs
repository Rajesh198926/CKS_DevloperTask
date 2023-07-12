using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CKS_DevloperTask.Models;
using Microsoft.AspNetCore.Authorization;
using AdminLTE.MVC.Data;

namespace CKS_DevloperTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        [Authorize]
        public IActionResult Index()
        {
            var userid = HttpContext.User.Identity.Name;
            ViewBag.TotalTasks = _applicationDbContext.ToDos.Where(i => i.IsDeleted == false && i.UserId == userid).Count();
            ViewBag.PendingTasks = _applicationDbContext.ToDos.Where(i => i.IsDeleted == false && i.IsActive == false && i.UserId == userid).Count();
            ViewBag.Notifications= _applicationDbContext.ToDos.Where(i => i.IsDeleted == false && i.DueDate.Date ==DateTime.Now.Date  && i.IsRemind==true && i.IsActive == true && i.UserId == userid).Count();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
