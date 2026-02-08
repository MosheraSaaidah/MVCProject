// using System.Xml.Linq;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
// using MVC_Project.Data;
// using MVC_Project.Models;
// using MVC_Project.Models.ViewModel;

// namespace MVC_Project.Areas.User.Controllers;


//  [Area("Admin")]
// public class ProductsController : Controller
// {
//    ApplicationDbContext context = new ApplicationDbContext();

//     public IActionResult Index()
//     {
//         var products = context.Products.Include(p=>p.Category).ToList();

//         var productVm = new List<ProductViewModel>();

//         foreach (var item in products)
//         {
//             var vm =new ProductViewModel
//             {
//                 id = item.id,
//                 name = item.name,
//                 image = item.image,

                
//             };
//             productVm.Add(vm);
            
//         }

//         return View(productVm);
//     }

//     public IActionResult Create()
//     {
//         ViewBag.categories = context.Categories.ToList();
//         return View(new Product() {});
//     }


//  public IActionResult Store(Product request, IFormFile image) 
// {
//     if(image != null && image.Length > 0)
//     {
//         var fileName = Guid.NewGuid().ToString();
//         fileName += Path.GetExtension(image.FileName);
//         var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName); // غيرها لـ images

//         using (var stream = System.IO.File.Create(filePath))
//         {
//             image.CopyTo(stream);
//         }

//         request.image = fileName;
//         context.Products.Add(request);
//         context.SaveChanges();
//         return RedirectToAction(nameof(Index));
//     }

//     return View("Create");
// }



//   public IActionResult Remove(int id)
//         {
//             var category = context.Categories.Find(id);

//            context.Categories.Remove(category);
            
//             context.SaveChanges();
//             return RedirectToAction(nameof(Index));

//         }
    
//         public IActionResult Update(Category request,int id)
//         {
//             if (ModelState.IsValid)
//             {
//                 context.Categories.Update(request);
//                 context.SaveChanges();
//                 return RedirectToAction(nameof(Index));
//             }
//             return View("Edit",request);
//         }


//         public IActionResult Edit (int id)
//         {
//              var category = context.Categories.Find(id);
//             return View(category);
//         }
    
//     }



using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using MVC_Project.Data;
using MVC_Project.Models;
using MVC_Project.Models.ViewModel;

namespace MVC_Project.Areas.User.Controllers;


[Area("Admin")]
public class ProductsController : Controller
{
    ApplicationDbContext context = new ApplicationDbContext();

    public IActionResult Index()
    {
        var products = context.Products.Include(p=>p.Category).ToList();

        var productVm = new List<ProductViewModel>();

        foreach (var item in products)
        {
            var vm = new ProductViewModel
            {
                id = item.id,
                name = item.name,
                image = item.image,
            };
            productVm.Add(vm);
        }

        return View(productVm);
    }

    public IActionResult Create()
    {
        ViewBag.categories = context.Categories.ToList();
        return View(new Product() {});
    }


    public IActionResult Store(Product request, IFormFile image) 
    {
        if(image != null && image.Length > 0)
        {
            var fileName = Guid.NewGuid().ToString();
            fileName += Path.GetExtension(image.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\image" , fileName);

            using (var stream = System.IO.File.Create(filePath))
            {
                image.CopyTo(stream);
            }

            request.image = fileName;
            context.Products.Add(request);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        return View("Create");
    }


    public IActionResult Remove(int id)
    {
        var product = context.Products.Find(id);

        if (product != null)
        {
           
            if (!string.IsNullOrEmpty(product.image))
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(),@"wwwroot\image" , product.image);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            context.Products.Remove(product);
            context.SaveChanges();
        }

        return RedirectToAction(nameof(Index));
    }

    
    public IActionResult Edit(int id)
    {
        var product = context.Products.Find(id);
        ViewBag.categories = context.Categories.ToList();
        return View(product);
    }


public IActionResult Update(Product request, int id, IFormFile image)
{
    ModelState.Remove("image");
    ModelState.Remove("Category");
    
    if (ModelState.IsValid)
    {
        var product = context.Products.Find(id);

        if (product != null)
        {
            // تحديث البيانات
            product.name = request.name;
            product.price = request.price;
            product.description = request.description;
            product.rate = request.rate;
            product.CategoryId = request.CategoryId;

            // إذا في صورة جديدة
            if (image != null && image.Length > 0)
            {
                // حذف الصورة القديمة
                if (!string.IsNullOrEmpty(product.image))
                {
                    var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(),@"wwwroot\image", product.image);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

              
                var fileName = Guid.NewGuid().ToString();
                fileName += Path.GetExtension(image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(),@"wwwroot\image", fileName);

                using (var stream = System.IO.File.Create(filePath))
                {
                    image.CopyTo(stream);
                }

                product.image = fileName;
            }

            context.Products.Update(product);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }

    var productFromDb = context.Products.Find(id);
    if (productFromDb == null)
    {
        return RedirectToAction(nameof(Index));
    }
    
    ViewBag.categories = context.Categories.ToList();
    return View("Edit", productFromDb);
}
}