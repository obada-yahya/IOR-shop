using Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Controllers
{
	public class LoginController : Controller
	{
		private readonly EcommerceContext context;
		public LoginController(EcommerceContext con)
		{
			context = con;
		}
		public IActionResult Index()
		{
			if(HttpContext.Session.GetInt32("userId") == null)
			{
				return RedirectToAction("Index","Home");
			}
			return View();
		}
        public IActionResult LoginUser()
        {
            return View("login");
        }
		[HttpPost]
		public IActionResult LoginUser(User user)
		{
			List<User> CheckUser = context.Users.Where(e => e.email.Equals(user.email) && e.password.Equals(user.password)).ToList();
			if(CheckUser.Count() == 0)
			{
                return View("login");
            }
			HttpContext.Session.SetInt32("userId", CheckUser.First().UserId);
			HttpContext.Session.SetString("name", CheckUser.First().name);
			if(user.cartId != null)
            HttpContext.Session.SetInt32("cartId", (int)CheckUser.First().cartId);

            return RedirectToAction("Index", "Home");
        }
        public IActionResult LoginAdmin()
		{
			return View("login");
		}
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Register(User user)
		{
			context.Users.Add(user); 
			context.SaveChanges();
			return View("Index","Home");	
		}

	}
}
