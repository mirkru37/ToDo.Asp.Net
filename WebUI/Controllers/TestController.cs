using Application;
using Application.Common.Interfaces;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[Route("test")]
public class TestController : Controller
{
    private readonly IRepository<UserEntity> _repository;

    public TestController(IRepository<UserEntity> repository)
    {
        _repository = repository;
    }
    
    // GET
    [Route("action")]
    [Authorize]
    public IActionResult Index()
    {
        new TestClass(_repository).TestMeth();
        UserEntity userEntity = new UserEntity();
        //userEntity.Id = 999; 
        //userEntity.Login = "login";
        //userEntity.Password = "password";
        _repository.Add(userEntity);
        return View();
    }
    
    [Route("get")]
    public IActionResult GetAll()
    {
        var userEntities = _repository.GetAll().Result;
        return View(userEntities);
    }
    
}