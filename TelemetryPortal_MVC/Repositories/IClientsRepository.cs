using TelemetryPortal_MVC.Models;

namespace TelemetryPortal_MVC.Repositories
{
    public interface IClientsRepository
    {
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client> GetByIdAsync(Guid id);
        Task AddAsync(Client client);
        Task UpdateAsync(Client client);
        Task DeleteAsync(Guid id);
        Task<bool> ClientExistsAsync(Guid id);
    }
}
