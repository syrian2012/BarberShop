using BarberShop.Data;
using BarberShop.Interfaces;
using BarberShop.Models;

namespace BarberShop.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly DataContext _context;

        public ServiceRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateService(Service service)
        {
            if (ServiceExsists(service.ServiceName))
                return false;
            _context.Add(service);
            return Save();
        }

        public Service GetService(string name)
        {
            return _context.Services.Where(s => s.ServiceName == name).FirstOrDefault();
        }

        public ICollection<Service> GetServices()
        {
            return _context.Services.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool ServiceExsists(string name)
        {
            return _context.Services.Any(s => s.ServiceName == name);
        }

        public bool UpdateService(Service service)
        {
            if(ServiceExsists(service.ServiceName))
                return false;
            _context.Update(service);
            return Save();
        }
    }
}
