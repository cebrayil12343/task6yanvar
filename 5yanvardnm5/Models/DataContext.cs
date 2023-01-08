using Microsoft.EntityFrameworkCore;

namespace _5yanvardnm5.Models
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

	    public DbSet<Slider> sliders { get; set; }
	    public DbSet<book> books { get; set; }
		public DbSet<Author> authors { get; set; }
		public DbSet<Genre> genres { get; set; }

	}
}
