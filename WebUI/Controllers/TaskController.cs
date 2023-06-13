using Application.Common.Interfaces;
using Application.Contracts.Task;
using Domain;
using Infrastructure.Repository;
using Ivony.Http.Pipeline.Handlers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
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

    // GET: Task
    [Authorize]
    public ActionResult Index()
    {
        var tasks = _repository.GetAll().Result.FindAll(t => t.UserID == User.Identity.GetUserId());
        return View(tasks);
    }

    // GET: Task/Details/{id}
    [Route("/details/{id}")]
    public ActionResult Details(string id)
    {
        var task = _repository.GetById(id);
        if (task == null)
        {
            return new NotFoundResult();
        }
        return View(task);
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
        _repository.Add(en);
        return RedirectToAction("Index");
    }
    
    [Route("delete")]
    public ActionResult Remove(string id)
    {
        var task = _repository.GetAll().Result.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            return new NotFoundResult();
        }
        return View(task);
    }

    // POST: Task/Delete/{id}
    [Route("deleteConfirmed")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(string id)
    {
        var task = _repository.GetAll().Result.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            return new NotFoundResult();
        }
        _repository.Delete(id);
        return RedirectToAction("Index");
    }
    
    [Route("done")]
    public ActionResult Done(string id)
    {
        var task = _repository.GetAll().Result.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            return new NotFoundResult();
        }

        ((TaskRepository) _repository).Done(id);
        return RedirectToAction("Index");
    }
}