using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSHOPING.Models;

namespace WebSHOPING.VIewsModel
{
    public class ProductModel
    {
        public List<Product> _products { get; set; }
        public List<Product> findAll()
        {
            _products = new List<Product> 
            { 
                     new Product()
                    {
                        id="1",
                        Name="Flower11",
                        Price=6.00
                    },
                    new Product()
                    {
                        id="2",
                        Name="Flower12",
                        Price=8.00
                    },
                     new Product()
                    {
                        id="3",
                        Name="Flower13",
                        Price=10.00
                    },
                      new Product()
                    {
                        id="4",
                        Name="Flower14",
                        Price=12.00
                    },
                       new Product()
                    {
                        id="5",
                        Name="Flower15",
                        Price=14.00
                    },
            };
            return _products;
        }
        public Product find(string id)
        {
            List<Product> products = findAll();
            var prod = products.Where(a => a.id == id).FirstOrDefault();
            return prod;
        }
    }
}
