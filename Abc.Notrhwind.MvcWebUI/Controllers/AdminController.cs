using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Northwind.Business.Abstract;
using Abc.Northwind.Entities.Concrete;
using Abc.Notrhwind.MvcWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Abc.Notrhwind.MvcWebUI.Controllers
{
	[Authorize(Roles ="Admin")]
	public class AdminController : Controller
	{

		private IProductService _productService;
		private ICategoryService _categoryService;

		public AdminController(IProductService productService, ICategoryService categoryService)
		{
			_productService = productService;
			_categoryService = categoryService;
		}

		public IActionResult Index()
		{

			var productListview = new ProductListViewModel()
			{
				Products = _productService.GetAll()
			};
			return View(productListview);
		}

		public IActionResult Insert()
		{

			var model = new ProductAddViewModel
			{
				Product = new Product(),
				Categories = _categoryService.GetAll()
			};
			return View(model);
		}


		[HttpPost]
		public IActionResult Insert(Product product)
		{
			if (ModelState.IsValid)
			{
				_productService.Add(product);
				TempData.Add("message", "Product succesfully added");
			}
			return RedirectToAction("Index");
		}
	
	
		public IActionResult Update(int productId)
		{
			var model = new ProductUpdateViewModel
			{
				Product = _productService.GetById(productId),
				Categories = _categoryService.GetAll()
			};
			return View(model);
		}
		[HttpPost]
		public IActionResult Update(Product product)
		{
			if (ModelState.IsValid)
			{
				_productService.Update(product);
				TempData.Add("message", "Product succesfully updated");
			}
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int productId)
		{

			_productService.Delete(productId);
			TempData.Add("message", "Product succesfully deleted");
			return RedirectToAction("Index");
		}
	}
}
