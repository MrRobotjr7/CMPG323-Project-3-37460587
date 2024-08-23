using TelemetryPortal_MVC.Models;
using System;

namespace TelemetryPortal_MVC.Repositories
{
    public interface IProjectsRepository
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(Guid id);
        Task AddProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(Guid id);
        Task<bool> ProjectExistsAsync(Guid id);





    }
}
