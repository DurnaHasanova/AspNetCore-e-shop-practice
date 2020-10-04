using Abc.Northwind.Entities.Concrete;
using Abc.Notrhwind.MvcWebUI.ExtensionMethods;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.Notrhwind.MvcWebUI.UIServices
{
	public interface ICartSessionService
	{
		Cart GetCard();
		void SetCard(Cart cart);

	}

	public class CartSessionService : ICartSessionService
	{//session klassini httpcontextden ancaq kontrollerde istifade elemek olar
		private IHttpContextAccessor _httpContextAccessor;

		public CartSessionService(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public Cart GetCard()
		{
			Cart cartTocheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
			if (cartTocheck == null)
			{
				_httpContextAccessor.HttpContext.Session.SetObject("cart", new Cart());
				cartTocheck= _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
			}
			return cartTocheck;
		}

		public void SetCard(Cart cart)
		{
			_httpContextAccessor.HttpContext.Session.SetObject("cart", cart);
		}
	}
}
