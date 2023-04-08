using BarberShop.Models;

namespace BarberShop.Interfaces
{
    public interface IReservationRepository
    {
        ICollection<Reservation> GetReservations();
        Reservation GetReservation(int id);
        Reservation GetReservationByMobile(string mobileNumber);
        bool CreateReservation(Reservation reservation);
        bool Save();
        bool DeleteReservation(string mobileNumber);
        bool AddReservationService(ReservationService reservationService);
    }
}
