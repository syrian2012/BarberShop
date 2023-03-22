namespace BarberShop.Models
{
    public class BarberService
    {
        public int BarberServiceId { get; set; }
        public int BarberId { get; set; }
        public int ServiceId { get; set; }
        public Barber Barber { get; set; }
        public Service Service { get; set; }
        public ICollection<ReservationService> ReservationServices { get; set; }
    }
}
