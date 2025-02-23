using Buisness.Factories;
using Buisness.Models.Dtos.CreateForm;
using Buisness.Models.Dtos.UpdateForm;
using Buisness.Models;
using DatabaseAssignment.Interfaces;
using DatabaseAssignment.Repositories;
using Buisness.Models.Dtos;

namespace Buisness.Services;

public class UserService(IUserRepository userRepository)
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<bool> CreateNewUserAsync(UserCreateForm form)
    {
        if (!await _userRepository.ExistsAsync(x => x.Email == form.Email))
        {
            var entity = UserFactory.Create(form);
            entity = await _userRepository.AddAsync(entity);
            if (entity != null && entity.Id > 0)
                return true;
        }
        return false;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        var entities = await _userRepository.GetAsync();
        return entities.Select(UserFactory.Create);
    }

    public async Task<User> GetActivityAsync(int id)
    {
        var entity = await _userRepository.GetAsync(x => x.Id == id);
        return entity != null ? UserFactory.Create(entity) : null!;
    }

    public async Task<bool> UpdateUserAsync(UserUpdateForm form)
    {
        var entity = await _userRepository.GetAsync(x => x.Id == form.Id);

        if (entity != null)
        {
            entity = UserFactory.Update(form);
            entity = await _userRepository.AddAsync(entity);
            if (entity != null && entity.Id == form.Id)
                return true;
        }
        return false;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var entity = await _userRepository.GetAsync(x => x.Id == id);

        if (entity != null)
        {
            var result = await _userRepository.RemoveAsync(entity);
            return result;
        }
        return false;
    }
}
