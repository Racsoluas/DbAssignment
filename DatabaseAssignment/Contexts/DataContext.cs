using DatabaseAssignment.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAssignment.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<ActivityStatusEntity> ActivityStatuses { get; set; }
    public DbSet<ArticleEntity> Articles { get; set; }
    public DbSet<CurrencyEntity> Currencies { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<ProjectEntity> Projects { get; set; }
    public DbSet<StatusTypeEntity> StatusTypes { get; set; }
    public DbSet<UserEntity> Users { get; set; }
}

