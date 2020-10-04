using Abc.Core.Entities;
using System;
using System.Linq;
using System.Text;

namespace Abc.Northwind.Entities.Concrete
{
	public class Category :IEntity
	{
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
	}
}
