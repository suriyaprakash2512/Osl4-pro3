﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppPro3.Models;

namespace WebAppPro3.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        List<User> userlist = new List<User>();
        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;


            userlist.Add(new Models.User { Username = "surya", Password = "surya@2001" });
            userlist.Add(new Models.User { Username = "priya", Password = "priya@2001" });
            userlist.Add(new Models.User { Username = "venkat", Password = "venkat@2001" });
        }

        public IActionResult Index() { 
            return View();
        }
        [HttpPost]
        public IActionResult Index(User u)
        {
            var found = userlist.Find(f => ((f.Username == u.Username) && (f.Password == u.Password)));

            if (found != null)
            {
                return RedirectToAction("Dashboard", "Home");
            }

            else
            {
                return View();
            }
        }
        public IActionResult Dashboard()
        {

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