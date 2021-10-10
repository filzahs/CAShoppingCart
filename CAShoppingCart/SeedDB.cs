using CAShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAShoppingCart
{
    public class SeedDB
    {
        private ShopContext shopContext;

        public SeedDB(ShopContext shopContext)
        {
            this.shopContext = shopContext;
        }

        public void Seed()
        {
            SeedProductTable();
        }

        public void SeedProductTable()
        {
            shopContext.Add(new Product
            {
                ProductName = ".NET Charts",
                Price = 99,
                Desc = "Brings powerful charting capabilities to your .NET applications.",
                ImageFile = "charts.png"
            });

            shopContext.Add(new Product
            {
                ProductName = ".NET PayPal",
                Price = 69,
                Desc = "Integrate your .NET apps with PayPal the easy way!",
                ImageFile = "paypal.png"
            });

            shopContext.Add(new Product
            {
                ProductName = ".NET ML",
                Price = 299,
                Desc = "Supercharged .NET machine learning libraries.",
                ImageFile = "ml.png"
            });

            shopContext.Add(new Product
            {
                ProductName = ".NET Analytics",
                Price = 299,
                Desc = "Perform data mining and analytics easily in .NET.",
                ImageFile = "analytics.png"
            });

            shopContext.Add(new Product
            {
                ProductName = ".NET Logger",
                Price = 49,
                Desc = "Logs and aggregates events easily in your.NET apps.",
                ImageFile = "logger.png"
            });

            shopContext.Add(new Product
            {
                ProductName = ".NET Numerics",
                Price = 199,
                Desc = "Powerful numerical methods for your .NET simulations.",
                ImageFile = "numerics.png"
            });

            shopContext.SaveChanges();

        }

    }
}
