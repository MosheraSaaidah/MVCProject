using Microsoft.AspNetCore.Mvc;
using MVC_Project.Data;
using MVC_Project.Models;

namespace MVC_Project.Areas.User.Controllers;


 [Area("Admin")]
public class ProductsController : Controller
{
   ApplicationDbContext context = new ApplicationDbContext();

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        ViewBag.categories = context.Categories.ToList();
        return View(new Product() {});
    }


    public IActionResult Store(Product request ,IFormFile Image)
    {
        if (ModelState.IsValid())
        {
            re
        }
        
    }


}
