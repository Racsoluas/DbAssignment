using DatabaseConsole.Data;
using DatabaseConsole.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseConsole.Services;

public class ProjectService
{
    private readonly AppDbContext _context;

    public ProjectService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Project>> GetAllProjects() => 
        await _context.Projects.ToListAsync();

    public async Task<Project?> GetProject(string projectNumber) => 
        await _context.Projects.FindAsync(projectNumber);

    public async Task<bool> CreateProject(Project project)
    {
        try
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> UpdateProject(string projectNumber, Project project)
    {
        try
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
