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
        public async Task<IActionResult> Create(Product model, IFormFile imageFile)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var extension =Path.GetExtension(imageFile.FileName);
            var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}");
            var path= Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/img",randomFileName);

            if(imageFile != null)
            {
                if(!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("", "Geçerli bir resim seçiniz");
                }
            }

            if (ModelState.IsValid)
            {
                using(var stream = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                model.Image = randomFileName;
                model.ProductId = Repository.Products.Count + 1;
                Repository.CreateProduct(model);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
            return View(model);
          
        }

        public IActionResult Edit(int? id)
        {

            if(id == null)
            {
                return NotFound();
            }
            var entity = Repository.Products.FirstOrDefault(p => p.ProductId == id);

            if (entity==null)
            {
                return NotFound();
            }

            ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(int id, Product model, IFormFile? imageFile) {

            if (id != model.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                if (imageFile != null)
                {
                    var extension = Path.GetExtension(imageFile.FileName);
                    var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}");
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    model.Image = randomFileName;
                }

                Repository.EditProduct(model);
                return RedirectToAction("Index");

            }
            ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
            return View(model);



        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

           var entity=  Repository.Products.FirstOrDefault(P => P.ProductId == id);

           if (entity == null)
            {
                return NotFound();
            }

           //Repository.DeleteProduct(entity);
           return View(entity);   



        }

        [HttpPost]
        public IActionResult Delete(int? id,int ProductId)
        {
            if (id != ProductId)
            {
                return NotFound();
            }

            var entity = Repository.Products.FirstOrDefault(P => P.ProductId == ProductId);

            if (entity == null)
            {
                return NotFound();
            }

            Repository.DeleteProduct(entity);
            return RedirectToAction("Index");



        }

        [HttpPost]
        public IActionResult EditProducts(List<Product> products)
        {
            foreach (var product in products)
            {
                Repository.EditIsActive(product);
            }

            return RedirectToAction("Index");

        }



    }
}