using FormsApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace FormsApp.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
        }

        public IActionResult Index(string searchString)
        {
            var products = Repository.Products;
            ViewBag.SearchString = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                string str3 = searchString.ToLowerInvariant(); // Kültür bağımsız dönüştürme

                products = products.Where(i => i.Name.ToLowerInvariant().Contains(str3)).ToList();
            }



            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
    }
}