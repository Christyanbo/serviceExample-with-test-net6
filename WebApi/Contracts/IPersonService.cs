using WebApi.Entities;
using WebApi.Request;

namespace WebApi.Contracts;

public interface IPersonService
{
    Task<Person> CreateAsync(PersonRequest personRequest);

    Task<Person> GetByIdAsync(int id);
}