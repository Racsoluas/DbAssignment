using DatabaseAssignment.Contexts;
using DatabaseAssignment.Entities;
using DatabaseAssignment.Interfaces;

namespace DatabaseAssignment.Repositories;

public class ActivityStatusRepository(DataContext context) : BaseRepository<ActivityStatusEntity>(context), IActivityStatusRepository
{

}

