using DatabaseAssignment.Contexts;
using DatabaseAssignment.Entities;
using DatabaseAssignment.Interfaces;

namespace DatabaseAssignment.Repositories;

public class UserRepository(DataContext context) : BaseRepository<UserEntity>(context), IUserRepository
{
    private readonly DataContext _context = context;


}