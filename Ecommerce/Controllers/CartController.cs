using Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Controllers
{
    public class CartController : Controller
    {
        private readonly EcommerceContext context;
        public CartController(EcommerceContext con)
        {
            context = con;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            int userId = (int)HttpContext.Session.GetInt32("userId");
            User user = context.Users.Find(userId);
            if(user.cartId == null)
            {
                ViewBag.products = new List<Product>();
            }
            else
            { 
                List<Cart> carts = context.Carts.Where(e=> e.cartId == user.cartId).ToList();
                List<Product> products = new List<Product>(); 
                foreach(Cart cart in carts)
                {
                    Product p = context.Products.Find(cart.productId);
                    products.Add(p);
                }
                ViewBag.products = products;
            }
            
            ViewBag.user = user;
            return View();
        }
        public IActionResult Delete(int productId)
        {
            if(HttpContext.Session.GetInt32("cartId") == null)
            {
                return RedirectToAction("index","Cart");
            }
            int cartId = (int)HttpContext.Session.GetInt32("cartId");
			List<Cart> cart = context.Carts.Where(e => e.productId == productId && e.cartId == cartId).ToList();
            if(cart == null)
            {
				return RedirectToAction("index", "Cart");
			}
            context.Carts.Remove(cart.First());
            context.SaveChanges();
			return RedirectToAction("index", "Cart");

		}
    }
}
