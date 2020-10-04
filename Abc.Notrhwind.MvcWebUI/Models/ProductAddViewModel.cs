using Abc.Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace Abc.Notrhwind.MvcWebUI
{
	public class ProductAddViewModel
	{
		public Product Product { get; set; }
		public List<Category> Categories { get; set; }
	}
}