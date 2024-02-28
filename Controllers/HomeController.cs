using FormsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace FormsApp.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
        }

        public IActionResult Index(string searchString,string category)
        {
            var products = Repository.Products;
            ViewBag.SearchString = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                string str3 = searchString.ToLowerInvariant(); // Kültür bağımsız dönüştürme

                products = products.Where(i => i.Name!.ToLowerInvariant().Contains(str3)).ToList();
            }

           // ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name",category);

            

            if (!string.IsNullOrEmpty(category) && category != "0") { 

                products = products.Where(p => p.CategoryId == int.Parse(category)).ToList();
            }

            var model = new ProductViewModel()
            {
                Products = products,
                Categories = Repository.Categories,
                SelectedCategory = category,
            };



            return View(model);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product model, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                model.ProductId = Repository.Products.Count + 1;
                Repository.CreateProduct(model);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
            return View(model);
          
        }


    }
}