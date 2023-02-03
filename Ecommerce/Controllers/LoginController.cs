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
            /*if (user.cartId != null)
                HttpContext.Session.SetInt32("cartId", (int)user.cartId);*/
        }
        public void adminLogin(Admin admin)
        {
            HttpContext.Session.SetInt32("adminId", admin.AdminId);
            HttpContext.Session.SetString("adminName", admin.name);
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
			return View("LoginAdmin");
		}
		[HttpPost]
		public IActionResult LoginAdmin(Admin admin)
        {
            List<Admin> CheckAdmin = context.Admins.Where(e => e.email.Equals(admin.email) && e.password.Equals(admin.password)).ToList();
            if (CheckAdmin.Count() == 0)
            {
                return View("LoginAdmin");
            }
            adminLogin(CheckAdmin.First());
			return RedirectToAction("AdminDashBoard", "Home");
        }
        public IActionResult LogOut()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Index", "Home");
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

        public IActionResult BasicInfo()
		{
            if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("Index", "Login");
            }
			int userId = (int)HttpContext.Session.GetInt32("userId");
			User user = context.Users.Find(userId);
            return View("BasicInfo",user);
		}
		[HttpPost]
		public IActionResult BasicInfo(User userUpdate)
		{
			// update the info and return to dashboard 
			// or clear the session and make them login in the new info

			User user = context.Users.Find(userUpdate.UserId);
			
			user.name = userUpdate.name;
            user.mobile = userUpdate.mobile;
            user.location = userUpdate.location;
            user.email = userUpdate.email;

			context.Users.Update(user);
			context.SaveChanges();
            HttpContext.Session.SetString("name", user.name);
            return RedirectToAction("Index", "Home");
        }
    }
}

