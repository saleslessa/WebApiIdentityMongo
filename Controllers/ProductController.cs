using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiWithMongo.Service;
using WebApiWithMongo.Models;

namespace WebApiWithMongo.Controllers
{

    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _productService.List();
            return View(products);
        }

        [HttpPost]
        public IActionResult Index(ProductViewModel model)
        {
            _productService.Add(model);
            var products = _productService.List();
            return View(products);
        }

    }
}
