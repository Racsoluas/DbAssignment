using DatabaseAssignment.Contexts;
using DatabaseAssignment.Entities;
using DatabaseAssignment.Interfaces;

namespace DatabaseAssignment.Repositories;

public class CurrencyStatusRepository(DataContext context) : BaseRepository<CurrencyEntity>(context), ICurrencyRepository
{

}

