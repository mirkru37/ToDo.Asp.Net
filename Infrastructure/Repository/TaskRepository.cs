using Application.Common.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class TaskRepository : IRepository<TaskEntity>
{
    
    private readonly IApplicationDBContext _dbContext;
    
    public TaskRepository(IApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task<List<TaskEntity>> GetAll()
    {
        return _dbContext.Tasks.ToListAsync();
    }

    public TaskEntity GetById(int id)
    {
        return _dbContext.Tasks.FirstOrDefault(c => c.Id == id);
    }

    public void Add(TaskEntity task)
    {
        _dbContext.Tasks.Add(task);
        _dbContext.SaveChangesAsync();
    }

    public void Update(TaskEntity task)
    {
        _dbContext.Tasks.Entry(task).State = EntityState.Modified;
        _dbContext.SaveChangesAsync();
    }

    public void Delete(int id)
    {
        var task = _dbContext.Tasks.FirstOrDefault(c => c.Id == id);
        if (task != null)
        {
            _dbContext.Tasks.Remove(task);
            _dbContext.SaveChangesAsync();
        }
    }
}