namespace BarberShop.Models
{
    public class ReservationService : BaseEntity
    {
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public int ServiceId { get; set; }
        public BarberService BarberService { get; set; }
    }
}
