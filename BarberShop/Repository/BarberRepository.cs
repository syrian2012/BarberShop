using BarberShop.Data;
using BarberShop.Interfaces;
using BarberShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Repository
{
    public class BarberRepository : IBarberRepository
    {
        private readonly DataContext _context;

        public BarberRepository(DataContext context)
        {
            _context = context;
        }

        public bool ActiveBarber(int id, DateTime? date, int period)
        {
            var barber = GetBarber(id);
            barber.SubscriptionDate = date;
            barber.SubscriptionPeriod = period;
            barber.IsActive = true;
            return Save();
        }

        public bool AddBarberEmployee(int barberId, string employeeName)
        {
            var barber = GetBarber(barberId);
            var barberEmployee = new BarberEmployee()
            {
                Barber = barber,
                EmployeeName = employeeName,
            };
            _context.Add(barberEmployee);
            return Save();
        }

        public bool BarberExists(int id)
        {
            return _context.Barbers.Any(b => b.UserId == id);
        }

        public bool CeateBarber(Barber barber)
        {
            _context.Add(barber);
            return Save();
        }

        public bool DeleteBarber(int id)
        {
            var barber = GetBarber(id);
            barber.DeleteTime = DateTime.Now;
            barber.IsDeleted = true;
            return Save();
        }

        public Barber GetBarber(int id)
        {
            return _context.Barbers.Where(b => b.UserId == id).FirstOrDefault();
        }

        public Barber GetBarberByReservation(int reservationId)
        {
            var reservation = _context.Reservations.Where(r => r.ReservationId == reservationId).FirstOrDefault();
            return reservation.Barber;
        }

        public ICollection<Barber> GetBarbers()
        {
            return _context.Barbers.ToList();
        }

        public ICollection<BarberService> GetBarberServices(int id)
        {
            return _context.BarberServices.Where(bs => bs.BarberId == id).ToList();
        }

        public ICollection<BarberEmployee> GetEmployeesOfBarber(int id)
        {
            var barber = _context.Barbers.Where(b => b.UserId == id).FirstOrDefault();
            return _context.BarberEmployees.Where(be => be.Barber == barber).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateBarber(Barber barber)
        {
            _context.Update(barber);
            return Save();
        }
    }
}
