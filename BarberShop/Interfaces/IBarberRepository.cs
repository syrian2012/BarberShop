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
        bool ActiveBarber(int id,DateTime? date,int period);
        bool DeleteBarber(int id);
        bool UpdateBarber(Barber barber);
        bool AddBarberEmployee(int barberId, string employeeName);
        ICollection<BarberEmployee> GetEmployeesOfBarber(int id);
        ICollection<BarberService> GetBarberServices(int id);
        bool Save();
    }
}
