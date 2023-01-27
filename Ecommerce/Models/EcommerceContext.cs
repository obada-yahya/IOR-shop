using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
	public class EcommerceContext: DbContext
	{
		public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Cart>().HasKey(x => new { x.cartId, x.productId });

		}
		public DbSet<User> Users{ get; set; }
		public DbSet<Admin> Admins { get; set; }

		public DbSet<Cart> Carts { get; set; }
		public DbSet<Categories> Categories { get; set; }

		public DbSet<Product> Products { get; set; }
	}
}
