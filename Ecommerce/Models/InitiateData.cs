using System.ComponentModel;
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
			// users
			User user1 = new User() { name = "mohammed", location="jenin",mobile="0123456789" ,email = "mohammed.an@gmail.com", password = "m1234" };
			User user2 = new User() { name = "ahmed", location = "jenin",mobile= "0112353214", email = "ahmed.an@gmail.com", password = "a1234" };
			context.Users.Add(user1);
			context.Users.Add(user2);
			// categories
			Categories c1 = new Categories() { categoryName = "Jackets" };
            Categories c2 = new Categories() { categoryName = "Trousers" };
            Categories c3 = new Categories() { categoryName = "Shirts" };
            Categories c4 = new Categories() { categoryName = "Shoes" };
			context.Categories.Add(c1);
            context.Categories.Add(c2);
            context.Categories.Add(c3);
            context.Categories.Add(c4);
			// Products
				// jackets
			Product p1 = new Product() { categoryId = 1,productName="jacket1",productImg= "jacket1.jpg",price=120};
			Product p2 = new Product() { categoryId = 1, productName = "jacket2", productImg = "jacket2.jpg", price = 120 };
			Product p3 = new Product() { categoryId = 1, productName = "jacket3", productImg = "jacket3.jpg", price = 150 };
			Product p4 = new Product() { categoryId = 1, productName = "jacket4", productImg = "jacket4.jpg", price = 170 };
			Product p5 = new Product() { categoryId = 1, productName = "jacket5", productImg = "jacket5.jpg", price = 200 };
			Product p6 = new Product() { categoryId = 1, productName = "jacket6", productImg = "jacket6.jpg", price = 130 };
			Product p7 = new Product() { categoryId = 1, productName = "jacket7", productImg = "jacket7.jpg", price = 160 };
			Product p8 = new Product() { categoryId = 1, productName = "jacket8", productImg = "jacket8.jpg", price = 120 };
			Product p9 = new Product() { categoryId = 1, productName = "jacket9", productImg = "jacket9.jpg", price = 200 };
			Product p10 = new Product() { categoryId = 1, productName = "jacket10", productImg = "jacket10.jpg", price = 220 };
            context.Products.Add(p1);
            context.Products.Add(p2);
            context.Products.Add(p3);
            context.Products.Add(p4);
            context.Products.Add(p5);
            context.Products.Add(p6);
            context.Products.Add(p7);
            context.Products.Add(p8);
            context.Products.Add(p9);
			context.Products.Add(p10);
            // Trousers
            Product p11 = new Product() { categoryId = 2, productName = "pants1", productImg = "pants1.jpg", price = 300 };
            Product p22 = new Product() { categoryId = 2, productName = "pants2", productImg = "pants2.jpg", price = 230 };
            Product p33 = new Product() { categoryId = 2, productName = "pants3", productImg = "pants3.jpg", price = 250 };
            Product p44 = new Product() { categoryId = 2, productName = "pants4", productImg = "pants4.jpg", price = 170 };
            Product p55 = new Product() { categoryId = 2, productName = "pants5", productImg = "pants5.jpg", price = 200 };
            Product p66 = new Product() { categoryId = 2, productName = "pants6", productImg = "pants6.jpg", price = 180 };
            Product p77 = new Product() { categoryId = 2, productName = "pants7", productImg = "pants7.jpg", price = 210 };
            Product p88 = new Product() { categoryId = 2, productName = "pants8", productImg = "pants8.jpg", price = 120 };
            Product p99 = new Product() { categoryId = 2, productName = "pants9", productImg = "pants9.jpg", price = 290 };
            Product p101 = new Product() { categoryId = 2, productName = "pants10", productImg = "pants10.jpg", price = 220 };
            context.Products.Add(p11);
            context.Products.Add(p22);
            context.Products.Add(p33);
            context.Products.Add(p44);
            context.Products.Add(p55);
            context.Products.Add(p66);
            context.Products.Add(p77);
            context.Products.Add(p88);
            context.Products.Add(p99);
            context.Products.Add(p101);
            // Shirts
            Product p111 = new Product() { categoryId = 3, productName = "shirt1", productImg = "shirt1.jpg", price = 250 };
            Product p222 = new Product() { categoryId = 3, productName = "shirt2", productImg = "shirt2.jpg", price = 150 };
            Product p333 = new Product() { categoryId = 3, productName = "shirt3", productImg = "shirt3.jpg", price = 270 };
            Product p444 = new Product() { categoryId = 3, productName = "shirt4", productImg = "shirt4.jpg", price = 230 };
            Product p555 = new Product() { categoryId = 3, productName = "shirt5", productImg = "shirt5.jpg", price = 210 };
            Product p666 = new Product() { categoryId = 3, productName = "shirt6", productImg = "shirt6.jpg", price = 240 };
            Product p777 = new Product() { categoryId = 3, productName = "shirt7", productImg = "shirt7.jpg", price = 210 };
            Product p888 = new Product() { categoryId = 3, productName = "shirt8", productImg = "shirt8.jpg", price = 120 };
            Product p999 = new Product() { categoryId = 3, productName = "shirt9", productImg = "shirt9.jpg", price = 190 };
            Product p102 = new Product() { categoryId = 3, productName = "shirt10", productImg = "shirt10.jpg", price = 220 };
            context.Products.Add(p111);
            context.Products.Add(p222);
            context.Products.Add(p333);
            context.Products.Add(p444);
            context.Products.Add(p555);
            context.Products.Add(p666);
            context.Products.Add(p777);
            context.Products.Add(p888);
            context.Products.Add(p999);
            context.Products.Add(p102);

            // shoes
            Product p1111 = new Product() { categoryId = 4, productName = "shoes1", productImg = "shoes1.jpg", price = 150 };
            Product p2222 = new Product() { categoryId = 4, productName = "shoes2", productImg = "shoes2.jpg", price = 180 };
            Product p3333 = new Product() { categoryId = 4, productName = "shoes3", productImg = "shoes3.jpg", price = 130 };
            Product p4444 = new Product() { categoryId = 4, productName = "shoes4", productImg = "shoes4.jpg", price = 140 };
            Product p5555 = new Product() { categoryId = 4, productName = "shoes5", productImg = "shoes5.jpg", price = 110 };
            Product p6666 = new Product() { categoryId = 4, productName = "shoes6", productImg = "shoes6.jpg", price = 170 };
            Product p7777 = new Product() { categoryId = 4, productName = "shoes7", productImg = "shoes7.jpg", price = 210 };
            Product p8888 = new Product() { categoryId = 4, productName = "shoes8", productImg = "shoes8.jpg", price = 120 };
            Product p9999 = new Product() { categoryId = 4, productName = "shoes9", productImg = "shoes9.jpg", price = 160 };
            Product p103 = new Product() { categoryId = 4, productName = "shoes10", productImg = "shoes10.jpg", price = 120 };
            context.Products.Add(p111);
            context.Products.Add(p222);
            context.Products.Add(p333);
            context.Products.Add(p444);
            context.Products.Add(p555);
            context.Products.Add(p666);
            context.Products.Add(p777);
            context.Products.Add(p888);
            context.Products.Add(p999);
            context.Products.Add(p102);
            context.SaveChanges();
		}
	}
}
