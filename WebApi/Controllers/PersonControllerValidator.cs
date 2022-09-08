using FluentValidation;
using WebApi.Request;

namespace WebApi.Controllers;

public class PersonControllerValidator: AbstractValidator<PersonRequest>
{
    public PersonControllerValidator()
    {
        RuleFor(p => p.FirstName).NotNull();        
        RuleFor(p => p.LastName).NotNull();
    }
}