using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_Project.Data;
using MVC_Project.Models;

namespace MVC_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {

        ApplicationDbContext _context = new ApplicationDbContext();

        public IActionResult Index()
        {
            var _categories = _context.Categories.ToList();

            return View(_categories);
            
        }

        public IActionResult Create()
        {
            return View() ;
        }

        public IActionResult Store (Category request)
        {
            var category = _context.Categories.Add(request);
            _context.SaveChanges();

            return  ;
        }
    }
}