﻿using Microsoft.EntityFrameworkCore;
using TelemetryPortal_MVC.Data;
using TelemetryPortal_MVC.Models;

namespace TelemetryPortal_MVC.Repositories
{

    public class ProjectsRepository(TechtrendsContext context) : IProjectsRepository
    {
        private readonly TechtrendsContext _context = context;

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(Guid id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task AddProjectAsync(Project project)
        {
            project.ProjectId = Guid.NewGuid();
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProjectAsync(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(Guid id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ProjectExistsAsync(Guid id)
        {
            return await _context.Projects.AnyAsync(e => e.ProjectId == id);
        }



    }
}
