using Application.Common.Interfaces;
using Domain;

namespace Application;

public class TestClass
{
    private readonly IRepository<UserEntity> _repository;
    
    public TestClass(IRepository<UserEntity> repository)
    {
        _repository = repository;
    }

    public void TestMeth()
    {
        var a = 1;
        
    }
}