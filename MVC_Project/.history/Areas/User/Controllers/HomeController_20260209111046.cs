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

        ApplicationDbContext context =new ApplicationDbContext();
        public IActionResult Index()
        {
            var categories = context.Categories.ToList();
            return View(categories);
        }

        public IActionResult Products(int id)
        {
            var Category = context.Categories.Find(id);
            if(Category == null)
            {
                return Content("Not Found");
            }
            var Product = cont
        }

    }
}