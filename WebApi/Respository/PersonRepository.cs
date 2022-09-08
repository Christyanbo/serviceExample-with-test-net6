using Microsoft.EntityFrameworkCore;
using WebApi.Controllers;
using WebApi.Database;
using WebApi.Entities;

namespace WebApi.Respository;

public class PersonRepository : IPersonRepository
{
    private readonly ApiContext _apiContext;

    public PersonRepository(ApiContext apiContext)
    {
        _apiContext = apiContext;
    }

    public async Task<Person> CreateAsync(Person person)
    {
        await _apiContext.Person.AddAsync(person);
        await _apiContext.SaveChangesAsync();

        return person;
    }

    public async Task<Person> GetByIdAsync(int id)
    {
        var result = await _apiContext.Person.FirstOrDefaultAsync(p => p.Id == id);

        return result;
    }
    
}