using DatabaseAssignment.Contexts;
using DatabaseAssignment.Entities;
using DatabaseAssignment.Interfaces;

namespace DatabaseAssignment.Repositories;

public class ArticleRepository(DataContext context) : BaseRepository<ArticleEntity>(context), IArticleRepository
{

}

