using Abc.Northwind.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Abc.Nortwind.DataAccess.Concrete.EntityFramework
{
	public class NorthwindContext:DbContext
	{

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=Northwind; Trusted_Connection=true"); 
		}
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
	}
}
