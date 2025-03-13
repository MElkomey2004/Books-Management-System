using Books_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Books_Management_System.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{



		}


		public DbSet<Book> Books { get;set; }




	}
}
