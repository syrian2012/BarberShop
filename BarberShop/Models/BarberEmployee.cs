namespace BarberShop.Models
{
    public class BarberEmployee : BaseEntity
    {
        public int BarberEmpolyeeId { get; set; }
        public string EmployeeName { get; set; }
        public Barber Barber { get; set; }
    }
}
