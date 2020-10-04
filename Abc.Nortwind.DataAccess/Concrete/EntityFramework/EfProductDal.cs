using Abc.Northwind.Entities.Concrete;
using Abc.Nortwind.DataAccess.Abstract;
using Abc.Nortwind.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Nortwind.DataAccess.Concrete.EntityFramework
{
	public class EfProductDal :EfEntityRepositoryBase<Product,NorthwindContext>, IProductDal
	{

	}

	
}
