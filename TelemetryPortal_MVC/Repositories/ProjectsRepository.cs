using TelemetryPortal_MVC.Data;
using TelemetryPortal_MVC.Models;
using TelemetryPortal_MVC.Repositories;

public class ProjectRepository : GenericRepository<Project>, IProjectsRepository
{
    public ProjectRepository(TechtrendsContext context) : base(context)
    {
    }

  
}
