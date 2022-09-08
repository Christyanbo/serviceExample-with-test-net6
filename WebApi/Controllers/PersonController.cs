using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.Contracts;
using WebApi.Request;

namespace WebApi.Controllers;

public class PersonController : ControllerBase
{
    public readonly IPersonService _personService;
    private readonly IValidator<PersonRequest> _validator;
    
    public PersonController(IPersonService personService,
        IValidator<PersonRequest> validator)
    {
        _personService = personService;
        _validator = validator;
    }

    [HttpPost("")]
    public async Task<IActionResult> Create([FromBody] PersonRequest personRequest)
    {
        var validation = await _validator.ValidateAsync(personRequest);

        if (!validation.IsValid)
        {
            return BadRequest(validation.Errors?.Select(e => new ValidationFailure()
            {
                ErrorCode = e.ErrorCode,
                PropertyName = e.PropertyName,
                ErrorMessage = e.ErrorMessage
            }));
        }

        var result = await _personService.CreateAsync(personRequest);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _personService.GetByIdAsync(id);

        return Ok(result);
    }
}