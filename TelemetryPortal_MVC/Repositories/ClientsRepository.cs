using TelemetryPortal_MVC.Data;
using TelemetryPortal_MVC.Models;
using TelemetryPortal_MVC.Repositories;

public class ClientRepository : GenericRepository<Client>, IClientsRepository
{
    public ClientRepository(TechtrendsContext context) : base(context)
    {
    }

}
