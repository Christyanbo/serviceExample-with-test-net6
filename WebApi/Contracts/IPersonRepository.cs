using WebApi.Entities;

namespace WebApi.Controllers;

public interface IPersonRepository
{
    Task<Person> CreateAsync(Person person);

    Task<Person> GetByIdAsync(int id);
}