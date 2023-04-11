using Application.Common.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[Route("users")]
public class UserController : Controller
{
    private readonly IRepository<UserEntity> _repository;

    public UserController(IRepository<UserEntity> repository)
    {
        _repository = repository;
        Console.WriteLine(repository.ToString());
    }

    [Route("action")]
    public IActionResult Index()
    {
        _repository.Add(new UserEntity());
        List<UserEntity> users = _repository.GetAll().Result;
        return View(users);
    }
}