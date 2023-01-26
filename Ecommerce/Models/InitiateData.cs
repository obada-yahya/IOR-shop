using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
namespace Ecommerce.Models
{
	public class InitiateData
	{
		public static void Initiate(EcommerceContext context)
		{
			context.Database.EnsureCreated();
			if (context.Users.Any())
			{
				return;
			}
			User user1 = new User() { name = "mohammed", location="jenin",mobile="0123456789" ,email = "mohammed.an@gmail.com", password = "m1234" };
			User user2 = new User() { name = "ahmed", location = "jenin",mobile= "0112353214", email = "ahmed.an@gmail.com", password = "a1234" };
			context.Users.Add(user1);
			context.Users.Add(user2);
			context.SaveChanges();
		}
	}
}
