using WebApi.Contracts;
using WebApi.Controllers;
using WebApi.Entities;
using WebApi.Request;

namespace WebApi.Services;

public class PersonService : IPersonService
{
    public readonly IPersonRepository _personRepository;
    
    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }
    public async Task<Person> CreateAsync(PersonRequest personRequest)
    {
        var person = new Person(personRequest.FirstName, personRequest.LastName);
        
        var result = await _personRepository.CreateAsync(person);

        return result;
    }

    public async Task<Person> GetByIdAsync(int id)
    {
        return await _personRepository.GetByIdAsync(id);
    }
}