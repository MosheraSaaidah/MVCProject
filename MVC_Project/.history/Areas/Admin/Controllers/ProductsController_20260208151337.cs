using Microsoft.AspNetCore.Mvc;

namespace MVC_Project.Areas.User.Controllers;


 [Area("Admin")]
public class ProductsController : Controller
{
   ApplicationDb

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }





}
