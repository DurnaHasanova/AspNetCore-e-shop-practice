using Abc.Notrhwind.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.Notrhwind.MvcWebUI.ViewComponents
{
	public class UserSummaryViewComponent :ViewComponent
	{
		

		public ViewViewComponentResult Invoke()
		{


			string Name = HttpContext.User.Identity.Name;
			UserDetailsViewModel model = new UserDetailsViewModel
			{
				UserName = Name
			};

			return View(model);
		}
	}
}
