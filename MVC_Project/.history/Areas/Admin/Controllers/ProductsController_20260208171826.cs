using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using MVC_Project.Data;
using MVC_Project.Models;

namespace MVC_Project.Areas.User.Controllers;


 [Area("Admin")]
public class ProductsController : Controller
{
   ApplicationDbContext context = new ApplicationDbContext();

    public IActionResult Index()
    {
        var products = c
        return View();
    }

    public IActionResult Create()
    {
        ViewBag.categories = context.Categories.ToList();
        return View(new Product() {});
    }


    public IActionResult Store(Product request ,IFormFile Image)
    {
    if(Image != null && Image.Length > 0)
        {
            var fileName = Guid.NewGuid().ToString();
            fileName += Path.GetExtension(Image.FileName);
        var filePath = Path.Combine(Directory.GetCurrentDirectory(),@"wwwroot\image" ,fileName);

            using (var strem = System.IO.File.Create(filePath))
            {
                Image.CopyTo(strem);
            }

            request.image = fileName;
            context.Products.Add(request);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
            
        }

        return View();
        
    }


}
