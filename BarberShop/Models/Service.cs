namespace BarberShop.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public ICollection<BarberService> BarberServices { get; set; }
    }
}
