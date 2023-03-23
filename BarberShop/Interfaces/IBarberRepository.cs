using BarberShop.Models;

namespace BarberShop.Interfaces
{
    public interface IBarberRepository
    {
        ICollection<Barber> GetBarbers();
        Barber GetBarber(int id);
        Barber GetBarberByReservation(int reservationId);
        bool BarberExists(int id);
        bool CeateBarber(Barber barber);
        bool DeleteBarber(int id);
        bool UpdateBarber(Barber barber);
        ICollection<BarberEmployee> GetEmployeesOfBarber(int id);
        ICollection<BarberService> GetBarberServices(int id);
        bool Save();
    }
}
