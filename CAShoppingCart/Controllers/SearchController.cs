using CAShoppingCart.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAShoppingCart.Controllers
{
    public class SearchController : Controller
    {
        private ShopContext shopContext;
        public SearchController(ShopContext shopContext)
        {
            this.shopContext = shopContext;
        }

        public IActionResult Index(string searchStr)
        {
            if (searchStr == null)
            {
                searchStr = "";
            }

            List<Product> products = shopContext.Products.Where(x =>
                x.ProductName.Contains(searchStr) || x.Desc.Contains(searchStr)
            ).ToList();

            //what does this lines do?
            ViewData["searchStr"] = searchStr;
            ViewData["products"] = products;

            return View();
        }
    }
}
