using System.Reflection.Metadata.Ecma335;

namespace BarberShop.Models
{
    public class Reservation : BaseEntity
    {
        public int ReservationId { get; set; }
        public DateTime ReservationDate { get; set; }
        public bool BarberApprove { get; set; }
        public bool CustomerApprove { get; set; }
        public string DeletedBy { get; set; }
        public int BarberId { get; set; }
        public Barber Barber { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<ReservationService> ReservationServices { get; set; }
    }
}
