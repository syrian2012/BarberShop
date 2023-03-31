using BarberShop.Data;
using BarberShop.Interfaces;
using BarberShop.Models;

namespace BarberShop.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateCustomer(Customer customer)
        {
            if (_context.Users.Any(c => c.MobileNumber == customer.MobileNumber))
                return false;
            _context.Add(customer);
            return Save();
        }

        public bool CustomerExists(string mobileNumber)
        {
            return _context.Customers.Any(c => c.MobileNumber == mobileNumber);
        }

        public bool DeleteCustomer(string mobileNumber)
        {
            var customer = GetCustomer(mobileNumber);
            customer.DeleteTime = DateTime.Now;
            customer.IsDeleted = true;
            return Save();
        }

        public Customer GetCustomer(string mobileNumber)
        {
            return _context.Customers.Where(c => c.MobileNumber == mobileNumber).FirstOrDefault();
        }

        public Customer GetCustomerByReservation(int reservationId)
        {
            var reservation = _context.Reservations.Where(r => r.ReservationId == reservationId).FirstOrDefault();
            return reservation.Customer;
        }

        public ICollection<Customer> GetCustomers()
        {
             return _context.Customers.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCustomer(Customer customer)
        {
            _context.Update(customer);
            return Save();
        }
    }
}
