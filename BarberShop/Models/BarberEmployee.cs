namespace BarberShop.Models
{
    public class BarberEmployee : BaseEntity
    {
        public string EmployeeName { get; set; }
        public Barber Barber { get; set; }
    }
}
