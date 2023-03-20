namespace BarberShop.Models
{
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        bool IsActive { get; set; }
    }
}
