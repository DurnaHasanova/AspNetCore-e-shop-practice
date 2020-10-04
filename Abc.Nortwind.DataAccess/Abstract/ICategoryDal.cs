using Abc.Core.DataAccess;
using Abc.Northwind.Entities.Concrete;

namespace Abc.Nortwind.DataAccess.Abstract
{
	public interface ICategoryDal : IEntityRepository<Category>
	{
		//burada ozel operasyonlar yaza biliriz 
	}

}
