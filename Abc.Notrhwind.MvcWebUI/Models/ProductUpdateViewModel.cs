using Abc.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Abc.Notrhwind.MvcWebUI
{
	public class ProductUpdateViewModel
	{
		public Product Product { get; set; }
		public List<Category> Categories { get; set; }
	}
}