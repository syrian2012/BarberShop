using BarberShop.Data;
using BarberShop.Interfaces;

namespace BarberShop.Repository
{
    public class BarberRepository : IBarberRepository
    {
        private readonly DataContext _context;

        public BarberRepository(DataContext context)
        {
            _context = context;
        }


    }
}
