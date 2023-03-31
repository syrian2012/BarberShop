using BarberShop.Models;

namespace BarberShop.Dto
{
    public class BarberEmployeeCreateDto
    {
        public string EmployeeName { get; set; }
        public Barber Barber { get; set; }
    }
}
