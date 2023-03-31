using BarberShop.Models;

namespace BarberShop.Interfaces
{
    public interface ICustomerRepository
    {
        ICollection<Customer> GetCustomers();
        Customer GetCustomer(string mobileNumber);
        Customer GetCustomerByReservation(int reservationId);
        bool CustomerExists(string mobileNumber);
        bool CreateCustomer(Customer customer);
        bool DeleteCustomer(string mobileNumber);
        bool UpdateCustomer(Customer customer);
        bool Save();
    }
}
