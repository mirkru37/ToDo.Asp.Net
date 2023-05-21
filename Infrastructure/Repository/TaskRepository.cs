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

    public TaskEntity GetById(string id)
    {
        return _dbContext.Tasks.FirstOrDefault(c => c.Id == id);
    }
 
    public void Add(TaskEntity task)
    {
        _dbContext.Tasks.Add(task);
        ((ApplicationDbContext) _dbContext).SaveChanges();
    }

    public async void Update(TaskEntity task)
    {
        _dbContext.Tasks.Entry(task).State = EntityState.Modified;
        await ((ApplicationDbContext) _dbContext).SaveChangesAsync();
    }

    public async void Delete(string id)
    {
        var task = _dbContext.Tasks.FirstOrDefault(c => c.Id == id);
        if (task != null)
        {
            _dbContext.Tasks.Remove(task);
            await ((ApplicationDbContext) _dbContext).SaveChangesAsync();
        }
    }
    
    
}