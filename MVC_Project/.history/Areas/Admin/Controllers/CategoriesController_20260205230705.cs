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

        ApplicationDbContext context = new ApplicationDbContext();

        public IActionResult Index()
        {
            var categories = context.Categories.ToList();

            return View(categories);
            
        }

        public IActionResult Create()
        {
            return View() ;
        }

        public IActionResult Store (Category request)
        {
            if (ModelState.IsValid)
            {
            var category = context.Categories.Add(request);
            context.SaveChanges();

            return RedirectToAction(nameof(Index)) ;
            }
            return View("create", request);
           
        }
    
        public IActionResult Remove(int id)
        {
            var category = context.Categories.Find(id);

           context.Categories.Remove(category);
            
            context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
    
        public 
    
    }
}