namespace Ecommerce.Models
{
	public class Product
	{
		public int productId { get; set; }
		public int categoryId { get; set; }
		public string productName { get; set; }
		public string productImg { get; set; }
		public double price { get; set; }

	}
}
