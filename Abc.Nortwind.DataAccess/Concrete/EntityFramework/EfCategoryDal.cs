using Abc.Northwind.Entities.Concrete;
using Abc.Nortwind.DataAccess.Abstract;
using Abc.Nortwind.DataAccess.EntityFramework;

namespace Abc.Nortwind.DataAccess.Concrete.EntityFramework
{
	public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
	{

	}

	
}
