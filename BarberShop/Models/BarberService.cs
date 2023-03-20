namespace BarberShop.Models
{
    public class BarberService
    {
        public int BarberId { get; set; }
        public int ServiceId { get; set; }
        public Barber Barber { get; set; }
        public Service Service { get; set; }
    }
}
