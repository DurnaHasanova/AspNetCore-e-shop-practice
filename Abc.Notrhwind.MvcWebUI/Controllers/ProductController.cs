using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Northwind.Business.Abstract;
using Abc.Notrhwind.MvcWebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Abc.Notrhwind.MvcWebUI.Controllers
{
	public class ProductController : Controller
	{
		IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		public IActionResult Index(int page=1, int category=0)
		{

			int pageSize = 10;


			
			var products = _productService.GetByCategoryId(category);
			ProductListViewModel model = new ProductListViewModel
			{
				Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
				PageCount = (int)Math.Ceiling(products.Count / (double)pageSize),
				PageSize = pageSize,
				CurrentCategory=category,
				CurrentPage=page
			};
			return View(model);
		}

		//public string Session()
		//{
		//	HttpContext.Session.SetString("city", "Ankara");
		//	HttpContext.Session.SetInt32("age", 32);
		//	HttpContext.Session.GetString("city");
		//	HttpContext.Session.GetInt32("age");


		//}

		
	}
}
