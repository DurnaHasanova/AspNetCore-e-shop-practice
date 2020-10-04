using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Northwind.Business.Abstract;
using Abc.Northwind.Entities.Concrete;
using Abc.Notrhwind.MvcWebUI.Models;
using Abc.Notrhwind.MvcWebUI.UIServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Abc.Notrhwind.MvcWebUI.Controllers
{
	public class CartController : Controller
	{
		private ICartSessionService _cartSessionService;
		private ICartService _cartService;
		private IProductService _productService;

		public CartController(ICartSessionService cartSessionService, ICartService cartService, IProductService productService)
		{
			_cartSessionService = cartSessionService;
			_cartService = cartService;
			_productService = productService;
		}

		public IActionResult AddToCart(int productId)
		{
			var productToBeAdded = _productService.GetById(productId);
			var cart = _cartSessionService.GetCard();
			_cartService.AddToCart(cart, productToBeAdded);
			_cartSessionService.SetCard(cart);
			TempData.Add("message", String.Format("Your product,{0}, was succesfully added to the cart!", productToBeAdded.ProductName));
			return RedirectToAction("Index", "Product");
		}
	
		public IActionResult List()
		{
			var cart = _cartSessionService.GetCard();
			CartSummaryViewModel model = new CartSummaryViewModel
			{
				Cart = cart
			};
			return View(model);
		}
		public IActionResult Remove(int productId)
		{
			var cart = _cartSessionService.GetCard();
			_cartService.RemoveFromCart(cart, productId);
			_cartSessionService.SetCard(cart);
			TempData.Add("message", string.Format("Your product has succesfully removed from cart!"));
			return RedirectToAction("List");
		}

		public IActionResult Complete()
		{
			var shippingDetailsViewModel = new ShippingDetailsViewModel
			{
				ShippingDetails = new ShippingDetails()
			};
			return View();
		}

		[HttpPost]
		public IActionResult Complete(ShippingDetailsViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			TempData.Add("message", string.Format("Thank you {0}, you order is in process", model.ShippingDetails.FirstName));
			_cartSessionService.SetCard(new Cart());
			return RedirectToAction("Index", "Product");
		}
	}
}
