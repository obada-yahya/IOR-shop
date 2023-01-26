using Ecommerce.Models;
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
