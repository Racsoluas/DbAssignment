using Buisness.Factories;
using Buisness.Models;
using Buisness.Models.Dtos.CreateForm;
using Buisness.Models.Dtos.UpdateForm;
using DatabaseAssignment.Interfaces;

namespace Buisness.Services;

public class ActivityStatusService(IActivityStatusRepository activityStatusRepository)
{
    private readonly IActivityStatusRepository _activityStatusRepository = activityStatusRepository;
    public async Task<bool> CreateNewActivityStatusAsync(ActivityStatusCreateForm form)
    {
        if (!await _activityStatusRepository.ExistsAsync(x => x.Status == form.Status))
        {
            var entity = ActivityStatusFactory.Create(form);
            entity = await _activityStatusRepository.AddAsync(entity);
            if (entity != null && entity.Id > 0) 
                return true;
        }
        return false;
    }

    public async Task<IEnumerable<ActivityStatus>> GetActivityStatuses()
    {
        var entities = await _activityStatusRepository.GetAsync();
        return entities.Select(ActivityStatusFactory.Create);
    }

    public async Task<ActivityStatus> GetActivityAsync(int id)
    {
        var entity = await _activityStatusRepository.GetAsync(x => x.Id == id);
        return entity != null ? ActivityStatusFactory.Create(entity) : null!;
    }

    public async Task<bool> UpdateActivityStatusAsync(ActivityStatusUpdateForm form)
    {
        var entity = await _activityStatusRepository.GetAsync(x => x.Id == form.Id);

        if (entity != null)
        {
            entity = ActivityStatusFactory.Update(form);
            entity = await _activityStatusRepository.AddAsync(entity);
            if (entity != null && entity.Id == form.Id)
                return true;
        }
        return false;
    }

    public async Task<bool> DeleteActivityStatusAsync(int id)
    {
        var entity = await _activityStatusRepository.GetAsync(x => x.Id == id);

        if (entity != null)
        {
            var result = await _activityStatusRepository.RemoveAsync(entity);
            return result;
        }
        return false;
    }
}
