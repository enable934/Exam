using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Exam.Model;
using Exam.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Exam.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        // GET
        public IActionResult Index()
        {
            return View(_productService.GetProducts());
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                _productService.CreateProduct(productModel);
                return RedirectToAction(nameof(Index));
            }
            return View(productModel);
        }
    }
}
