﻿using FormsApp.Models;
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

                products = products.Where(i => i.Name.ToLowerInvariant().Contains(str3)).ToList();
            }

            ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");

            if (!string.IsNullOrEmpty(category) && category != "0") { 

                products = products.Where(p => p.CategoryId == int.Parse(category)).ToList();
            }


            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
    }
}