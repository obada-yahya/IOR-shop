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
            int cartId = userId;
            User user = context.Users.Find(userId); 
            List<Cart> carts = context.Carts.Where(e=> e.cartId == cartId).ToList();
            ViewBag.user = user;
            if (carts.Count() == 0)
            {
                ViewBag.products = new List<Product>();
                return View();
            }
            List<Product> products = new List<Product>();
            foreach(Cart cart in carts)
            {
                Product p = context.Products.Find(cart.productId);
                products.Add(p);
            }
            ViewBag.products = products;
            return View();
        }
        public IActionResult addProduct(int Id)
        {
            if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("index", "Home");
            }
            int userId = (int)HttpContext.Session.GetInt32("userId");
            Cart cart = new Cart() { cartId = userId, productId = Id };
            List<Cart> searchCart = context.Carts.Where(e=> e.cartId == cart.cartId && e.productId == cart.productId).ToList();
            if(searchCart.Count() > 0)
            {
                return RedirectToAction("index", "Cart");
            }

            context.Carts.Add(cart);
            context.SaveChanges();
            return RedirectToAction("index","Cart");
        }
        public IActionResult Delete(int productId)
        {
            if(HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("index","Cart");
            }
            int cartId = (int)HttpContext.Session.GetInt32("userId");
			List<Cart> cart = context.Carts.Where(e => e.productId == productId && e.cartId == cartId).ToList();
            if(cart.Count() == 0)
            {
				return RedirectToAction("index", "Cart");
			}
            context.Carts.Remove(cart.First());
            context.SaveChanges();
			return RedirectToAction("index", "Cart");

		}
    }
}
