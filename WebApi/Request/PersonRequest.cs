namespace WebApi.Request;

public class PersonRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public PersonRequest(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}