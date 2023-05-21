using Application.Common.Interfaces;
using Application.Contracts.Task;
using Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebUI.Models;

namespace WebUI.Controllers;

[Route("task")]
public class TaskController : Controller
{
    private readonly Microsoft.AspNetCore.Identity.UserManager<UserEntity> _userManager;
    private readonly IRepository<TaskEntity> _repository;
    
    public TaskController(Microsoft.AspNetCore.Identity.UserManager<UserEntity> userManager, IRepository<TaskEntity> repository)
    {
        _userManager = userManager;
        _repository = repository;
    }

    [Route("new")]
    public IActionResult New()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateContract task)
    {
        var user = _userManager.Users.First(u => u.UserName == User.Identity.Name);
        task.User = user;
        task.Id = Guid.NewGuid().ToString();
        //ModelState.AddModelError("Name", "Reee");
        if (!ModelState.IsValid)
        {
            return View("New", task);
        }

        var en = new TaskEntity
        {
            Id = task.Id,
            UserID = user.Id,
            Name = task.Name,
            Description = task.Description,
            Deadline = task.Deadline,
            Priority = task.Priority,
        };
        //_repository.Add(new TaskEntity{Id = Guid.NewGuid().ToString(), Name = "ddd", UserID = "dd"});
        _repository.Add(en);
        return Redirect("/test/action");
    }
}