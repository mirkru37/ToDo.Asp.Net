using Application;
using Application.Common.Interfaces;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[Route("test")]
public class TestController : Controller
{
    private readonly IRepository<TaskEntity> _repository;

    public TestController(IRepository<TaskEntity> repository)
    {
        _repository = repository;
    }
    
    // GET
    [Route("action")]
    [Authorize]
    public IActionResult Index()
    {
        Console.WriteLine(_repository.GetAll());
        return View();
    }

}