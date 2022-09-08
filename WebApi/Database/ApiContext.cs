using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Database;

public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions<ApiContext> options) : base(options)
    { }
    
    public virtual DbSet<Person> Person { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Person>().HasData(
            new List<Person>()
            {
                new Person()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Lennon"
                },
                new Person()
                {
                    Id = 2,
                    FirstName = "Michael",
                    LastName = "Jordan"
                },
                new Person()
                {
                    Id = 3,
                    FirstName = "Rony",
                    LastName = "Coleman"
                }
            });
    }
}