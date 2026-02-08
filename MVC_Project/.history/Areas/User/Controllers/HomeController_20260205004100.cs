using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_Project.Data;

namespace MVC_Project.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {

        ApplicationDbContext c
        public IActionResult Index()
        {
            return View();
        }
    }
}