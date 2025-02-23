using DatabaseConsole.Models;
using System.Net.Http.Json;
using Microsoft.EntityFrameworkCore;
using DatabaseConsole.Data;

namespace DatabaseConsole.Services;

public class ProjectManagerService
{
    private readonly AppDbContext _context;

    public ProjectManagerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProjectManager>> GetAllProjectManagers() => 
        await _context.ProjectManagers.ToListAsync();

    public async Task<ProjectManager?> GetProjectManager(int id) => 
        await _context.ProjectManagers.FindAsync(id);

    public async Task<bool> CreateProjectManager(ProjectManager manager)
    {
        try
        {
            await _context.ProjectManagers.AddAsync(manager);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> UpdateProjectManager(int id, ProjectManager manager)
    {
        try
        {
            _context.ProjectManagers.Update(manager);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
