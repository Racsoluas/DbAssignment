using Buisness.Factories;
using Buisness.Models.Dtos;
using Buisness.Models.Dtos.CreateForm;
using Buisness.Models.Dtos.UpdateForm;
using DatabaseAssignment.Interfaces;

namespace Buisness.Services;

    public class ProjectService(IProjectRepository projectRepository)
    {
        private readonly IProjectRepository _projectRepository = projectRepository;
         public async Task<bool> CreateNewProjectAsync(ProjectCreateForm form)
        {
            if (!await _projectRepository.ExistsAsync(x => x.ProjectName == form.ProjectName))
            {
            var entity = ProjectFactory.Create(form);
            entity = await _projectRepository.AddAsync(entity);
            if (entity != null && entity.Id > 0) 
                return true;
            }
            return false;
    }

    public async Task<IEnumerable<Project>> GetProjects()
    {
        var entities = await _projectRepository.GetAsync();
        return entities.Select(ProjectFactory.Create);
    }

    public async Task<Project?> GetProjectAsync(int id)
    {
        var entity = await _projectRepository.GetAsync(x => x.Id == id);
        return entity != null ? ProjectFactory.Create(entity) : null!;
    }

    public async Task<bool> UpdateProjectAsync(ProjectUpdateForm form)
    {
        var entity = await _projectRepository.GetAsync(x => x.Id == form.Id);

        if (entity != null)
        {
            entity = ProjectFactory.Update(form);
            entity = await _projectRepository.AddAsync(entity);
            if (entity != null && entity.Id == form.Id)
                return true;
        }
        return false;
    }

    public async Task<bool> DeleteProjectAsync(int id)
    {
        var entity = await _projectRepository.GetAsync(x => x.Id == id);

        if (entity != null)
        {
            var result = await _projectRepository.RemoveAsync(entity);
            return result;
        }
        return false;
    }
}
