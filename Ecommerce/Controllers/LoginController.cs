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
			return View();
		}
		public void userLogin(User user)
		{
            HttpContext.Session.SetInt32("userId", user.UserId);
            HttpContext.Session.SetString("name", user.name);
            if (user.cartId != null)
                HttpContext.Session.SetInt32("cartId", (int)user.cartId);
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
			userLogin(CheckUser.First());
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
            userLogin(user);
            return RedirectToAction("Index","Home");	
		}

	}
}
