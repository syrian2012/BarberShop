using BarberShop.Data;
using BarberShop.Interfaces;
using BarberShop.Models;

namespace BarberShop.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public User GetUserByMobile(string mobileNumber)
        {
            return _context.Users.Where(u => u.MobileNumber == mobileNumber.Trim()).FirstOrDefault();
        }

        public bool Login(string mobileNumber, string password)
        {
            if(!UserExists(mobileNumber))
                return false;
            var user = GetUserByMobile(mobileNumber);
            if (user.Password != password)
                return false;
            return true;
        }

        public bool UserExists(string mobileNumber)
        {
            return _context.Users.Any(u => u.MobileNumber == mobileNumber);
        }
    }
}
