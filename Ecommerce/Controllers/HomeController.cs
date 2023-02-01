using Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
	public class HomeController : Controller
	{
        private readonly EcommerceContext context;
        public HomeController(EcommerceContext con)
		{
			context = con;
		}

		public IActionResult Index()
		{
			if(HttpContext.Session.GetInt32("userId")  == null)
			{
				return RedirectToAction("Index", "Login");
			}
            return View(new User() { name=HttpContext.Session.GetString("name") });
        }

		public IActionResult DashBoard(int id)
		{
			Categories category = context.Categories.Find(id);
			List<Product> products = context.Products.Where(e => e.categoryId == id).ToList();
			ViewBag.products = products;
			ViewBag.category = category;
			return View();
		}
		public IActionResult AboutUs() { return View(); }
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
