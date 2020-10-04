using Abc.Core.DataAccess;
using Abc.Northwind.Entities.Concrete;
using Abc.Nortwind.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Nortwind.DataAccess.Abstract
{
	public interface IProductDal :IEntityRepository<Product>
	{
		//burada ozel operasyonlar yaza biliriz 
	}

}
