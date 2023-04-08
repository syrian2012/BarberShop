using BarberShop.Models;

namespace BarberShop.Interfaces
{
    public interface IServiceRepository
    {
        ICollection<Service> GetServices();
        Service GetService(string name);
        bool CreateService(Service service);
        bool UpdateService(Service service);
        bool Save();
        bool ServiceExsists(string name);
    }
}
