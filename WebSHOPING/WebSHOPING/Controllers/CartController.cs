using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSHOPING.Helpers;
using WebSHOPING.Models;
using WebSHOPING.VIewsModel;

namespace WebSHOPING.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);

            return View();
        }
        private int isExist (string id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i=0;i<cart.Count;i++)
            {
                if(cart[i].Product.id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
        public IActionResult Buy (string id )
        {
            ProductModel productModel = new ProductModel();
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = productModel.find(id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index!= -1)
                {
                    cart[index].Quantity++;

                }
                else
                {
                    cart.Add(new Item { Product = productModel.find(id), Quantity = 1 });

                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            }
            
            return RedirectToAction("index", "Product");
        }
        public IActionResult Remove (string id )
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("index");
        }
    }


}