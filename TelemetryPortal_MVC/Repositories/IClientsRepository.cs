using TelemetryPortal_MVC.Models;

namespace TelemetryPortal_MVC.Repositories
{
    public interface IClientsRepository
    {
        IEnumerable<Client> GetAll();  
        Client GetById(Guid clientId);  
        void Add(Client client);  
        void Update(Client client);  
        void Delete(Guid clientId);  
        bool ClientExists(Guid clientId);  


    }
}
