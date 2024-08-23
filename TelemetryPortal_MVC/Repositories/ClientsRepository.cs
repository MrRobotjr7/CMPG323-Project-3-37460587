using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetByIdAsync(Guid clientId)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.ClientId == clientId);
        }

        public async Task AddAsync(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid clientId)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.ClientId == clientId);
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ClientExistsAsync(Guid clientId)
        {
            return await _context.Clients.AnyAsync(e => e.ClientId == clientId);
        }
    }
}
