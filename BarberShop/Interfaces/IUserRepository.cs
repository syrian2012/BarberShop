using BarberShop.Models;

namespace BarberShop.Interfaces
{
    public interface IUserRepository
    {
        bool Login(string mobileNumber, string password);
        User GetUserByMobile(string mobileNumber);
        bool UserExists(string mobileNumber);
    }
}
