using Application.Common.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class FolderRepository : IRepository<FolderEntity>
{
    
    private readonly IApplicationDBContext _dbContext;
    
    public FolderRepository(IApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task<List<FolderEntity>> GetAll()
    {
        return _dbContext.Folders.ToListAsync();
    }

    public FolderEntity GetById(int id)
    {
        return _dbContext.Folders.FirstOrDefault(c => c.Id == id);
    }

    public void Add(FolderEntity folder)
    {
        _dbContext.Folders.Add(folder);
        _dbContext.SaveChangesAsync();
    }

    public void Update(FolderEntity folder)
    {
        _dbContext.Folders.Entry(folder).State = EntityState.Modified;
        _dbContext.SaveChangesAsync();
    }

    public void Delete(int id)
    {
        var folder = _dbContext.Folders.FirstOrDefault(c => c.Id == id);
        if (folder != null)
        {
            _dbContext.Folders.Remove(folder);
            _dbContext.SaveChangesAsync();
        }
    }
}