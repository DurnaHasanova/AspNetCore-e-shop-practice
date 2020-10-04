using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Notrhwind.MvcWebUI.Entities;
using Abc.Notrhwind.MvcWebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Abc.Notrhwind.MvcWebUI.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<CustomIdentityUser> userManager;
		private readonly RoleManager<CustomIdentityRole> roleManager;
		private readonly SignInManager<CustomIdentityUser> signInManager;

		public AccountController(UserManager<CustomIdentityUser> userManager, RoleManager<CustomIdentityRole> roleManager,
			SignInManager<CustomIdentityUser> signInManager)
		{
			this.userManager = userManager;
			this.roleManager = roleManager;
			this.signInManager = signInManager;
		}
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Register(RegistervVewModel model)
		{
			if (ModelState.IsValid)
			{
				CustomIdentityUser user = new CustomIdentityUser
				{
					UserName = model.UserName,
					Email = model.Email
				};


				IdentityResult result = userManager.CreateAsync(user, model.Password).Result;
				if (result.Succeeded)
				{
					if (!roleManager.RoleExistsAsync("Admin").Result)
					{
						CustomIdentityRole role = new CustomIdentityRole
						{
							Name = "Admin"
						};
						IdentityResult roleResult = roleManager.CreateAsync(role).Result;

						if (!roleResult.Succeeded)
						{
							ModelState.AddModelError("", " We can't add the role!");
							return View(model);

						}
					}
					userManager.AddToRoleAsync(user, "Admin").Wait();
					return RedirectToAction("Login", "Account");

				}
			}
				return View(model);
		}
	
		public IActionResult Login()
		{

			
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var result = signInManager.PasswordSignInAsync(model.UserName, model.Password, model.Rememberme, false).Result;
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Admin");
				}
			
			}
			ModelState.AddModelError("", "Invalid Login");


			return View(model);
		}

		//[HttpPost]
		//[ValidateAntiForgeryToken]
		public IActionResult SignOut()
		{
			signInManager.SignOutAsync().Wait();
			return RedirectToAction("Login");
		}
	}
}
