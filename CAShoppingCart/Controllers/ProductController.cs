using CAShoppingCart.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAShoppingCart.Controllers
{
    public class ProductController : Controller
    {
        private ShopContext shopContext;
        public ProductController(ShopContext shopContext)
        {
            this.shopContext = shopContext;
        }

        public IActionResult AllProducts(string searchStr)
        {
            //check session id here

            //if no search string will just list all products
            if (searchStr == null)
            {
                searchStr = "";
            }

            List<Product> products = shopContext.Products.Where(x =>
                x.ProductName.Contains(searchStr)
            ).ToList();

            //what does this lines do?
            ViewData["searchStr"] = searchStr;
            ViewData["products"] = products;

            return View();
        }
    }
}
