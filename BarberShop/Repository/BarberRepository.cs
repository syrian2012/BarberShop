using BarberShop.Data;
using BarberShop.Interfaces;
using BarberShop.Models;

namespace BarberShop.Repository
{
    public class BarberRepository : IBarberRepository
    {
        private readonly DataContext _context;

        public BarberRepository(DataContext context)
        {
            _context = context;
        }

        public bool ActiveateBarber(string mobileNumber, DateTime? date, int period)
        {
            var barber = GetBarber(mobileNumber);
            barber.SubscriptionDate = date;
            barber.SubscriptionPeriod = period;
            barber.IsActive = true;
            return Save();
        }

        public bool AddBarberEmployee(string mobileNumber, string employeeName)
        {
            var barber = GetBarber(mobileNumber);
            var barberEmployee = new BarberEmployee()
            {
                Barber = barber,
                EmployeeName = employeeName,
                CreateTime = DateTime.Now,
                IsDeleted = false,
            };
            _context.Add(barberEmployee);
            return Save();
        }

        public bool AddBarberService(BarberService barberService)
        {
            _context.Add(barberService);
            return Save();
        }

        public bool BarberExists(string mobileNumber)
        {
            return _context.Barbers.Any(b => b.MobileNumber == mobileNumber);
        }

        public bool CreateBarber(Barber barber)
        {
            if(_context.Users.Any(b => b.MobileNumber == barber.MobileNumber))
                return false;
            _context.Add(barber);
            return Save();
        }

        public bool DeleteBarber(string mobileNumber)
        {
            var barber = GetBarber(mobileNumber);
            barber.DeleteTime = DateTime.Now;
            barber.IsDeleted = true;
            return Save();
        }

        public Barber GetBarber(string mobileNumber)
        {
            return _context.Barbers.Where(b => b.MobileNumber == mobileNumber).FirstOrDefault();
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

        public ICollection<BarberService> GetBarberServices(string mobileNumber)
        {
            var barber = GetBarber(mobileNumber);
            return _context.BarberServices.Where(bs => bs.BarberId == barber.UserId).ToList();
        }

        public ICollection<BarberEmployee> GetEmployeesOfBarber(string mobileNumber)
        {
            var barber = GetBarber(mobileNumber);
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
