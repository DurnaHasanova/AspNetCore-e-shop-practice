using Abc.Northwind.Business.Abstract;
using Abc.Northwind.Entities.Concrete;
using Abc.Nortwind.DataAccess.Abstract;
using System.Collections.Generic;

namespace Abc.Northwind.Business.Concrete
{
	public class CategoryManager : ICategoryService
	{
		private ICategoryDal _categoryDal;

		public CategoryManager(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;
		}

		public List<Category> GetAll()
		{
			return _categoryDal.GetList();
		}
	}
}
