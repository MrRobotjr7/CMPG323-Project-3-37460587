using TelemetryPortal_MVC.Data;
using TelemetryPortal_MVC.Models;

namespace TelemetryPortal_MVC.Repositories
{
    public class ClientsRepository : IClientsRepository
    {

        protected readonly TechtrendsContext _context;
        
            public ClientsRepository(TechtrendsContext context)
        {
               _context = context;
        
        }

        

        public IEnumerable<Client> GetAll()
        { 
            return _context.Clients.ToList();
        }
        public Client GetById(Guid clientId)
        {
            return _context.Clients.FirstOrDefault(c => c.ClientId == clientId);
        }

        public void Add(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }
        public void Update(Client client)
        {
            _context.Clients.Update(client);
            _context.SaveChanges();
        }

        public void Delete(Guid clientId)
        {
            var client = _context.Clients.FirstOrDefault(c => c.ClientId == clientId);
            if (client != null)
            {
                _context.Clients.Remove(client);
                _context.SaveChanges();
            }
        }
        public bool ClientExists(Guid clientId)
        {
            return _context.Clients.Any(e => e.ClientId == clientId);
        }
    }
}
