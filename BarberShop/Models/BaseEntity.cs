namespace BarberShop.Models
{
    public class BaseEntity
    {
        public DateTime? DeleteTime { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
