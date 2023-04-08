using BarberShop.Models;

namespace BarberShop.Interfaces
{
    public interface IBarberRepository
    {
        ICollection<Barber> GetBarbers();
        Barber GetBarber(string mobileNumber);
        Barber GetBarberByReservation(int reservationId);
        bool BarberExists(string mobileNumber);
        bool CreateBarber(Barber barber);
        bool ActiveateBarber(string mobileNumber, DateTime? date,int period);
        bool DeleteBarber(string mobileNumber);
        bool UpdateBarber(Barber barber);
        bool AddBarberEmployee(string mobileNumber, string employeeName);
        ICollection<BarberEmployee> GetEmployeesOfBarber(string mobileNumber);
        ICollection<BarberService> GetBarberServices(string mobileNumber);
        bool Save();
        bool AddBarberService(BarberService barberService);
    }
}
