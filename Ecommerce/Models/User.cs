namespace Ecommerce.Models
{
	public class User
	{
		public int UserId { get; set; }
		public string name { get; set; }
		public string email { get; set; }
		public string password { get; set; }
		public string location { get; set; }
		public string mobile { get; set; }
        public int? cartId { get; set; }
    }
}
