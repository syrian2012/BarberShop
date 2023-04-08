using BarberShop.Data;
using BarberShop.Interfaces;
using BarberShop.Models;

namespace BarberShop.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly DataContext _context;

        public ReservationRepository(DataContext context)
        {
            _context = context;
        }

        public bool AddReservationService(ReservationService reservationService)
        {
            _context.Add(reservationService);
            return Save();
        }

        public bool CreateReservation(Reservation reservation)
        {
            reservation.CreateTime= DateTime.Now;
            _context.Add(reservation);
            return Save();
        }

        public bool DeleteReservation(string mobileNumber)
        {
            var reservation = GetReservationByMobile(mobileNumber);
            if (reservation == null)
                return false;
            reservation.IsDeleted = true;
            reservation.DeletedBy = "";
            reservation.DeleteTime= DateTime.Now;
            return Save();
        }

        public Reservation GetReservation(int id)
        {
            return _context.Reservations.Where(r => r.ReservationId == id).FirstOrDefault();
        }

        public Reservation GetReservationByMobile(string mobileNumber)
        {
            return _context.Reservations.Where(r => r.Customer.MobileNumber == mobileNumber 
            || r.Barber.MobileNumber == mobileNumber).FirstOrDefault();
        }

        public ICollection<Reservation> GetReservations()
        {
            return _context.Reservations.OrderBy(r => r.CreateTime).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
