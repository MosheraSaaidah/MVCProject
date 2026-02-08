using Microsoft.AspNetCore.Mvc;
using MVC_Project.Data;

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
        var categories = context.Product.ToList();
        return View(categories);
    }





}
