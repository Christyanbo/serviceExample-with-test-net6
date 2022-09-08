using AutoFixture;
using Moq;
using WebApi.Controllers;
using WebApi.Entities;
using WebApi.Services;

namespace TestProject1;

public class UnitTest1
{
    [Fact]
    public async Task GetByIdTest()
    {
        var id = 1;
        var person = new Fixture().Create<Task<Person>>();
        
        var mockPersonRepository = new Mock<IPersonRepository>();

        mockPersonRepository.Setup(p => p.GetByIdAsync(1))
            .Returns(person);
        
        var service = new PersonService(mockPersonRepository.Object);

        var result = await service.GetByIdAsync(1);
        
        Assert.Equal(await person, result);

        mockPersonRepository.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Once);
    }
}