using Application.Common.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class TagRepository : IRepository<TagEntity>
{
    
    private readonly IApplicationDBContext _dbContext;
    
    public TagRepository(IApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task<List<TagEntity>> GetAll()
    {
        return _dbContext.Tags.ToListAsync();
    }

    public TagEntity GetById(string id)
    {
        return _dbContext.Tags.FirstOrDefault(c => c.Id == id);
    }

    public void Add(TagEntity tag)
    {
        _dbContext.Tags.Add(tag);
        ((ApplicationDbContext) _dbContext).SaveChangesAsync();
    }

    public void Update(TagEntity tag)
    {
        _dbContext.Tags.Entry(tag).State = EntityState.Modified;
        ((ApplicationDbContext) _dbContext).SaveChangesAsync();
    }

    public void Delete(string id)
    {
        var tag = _dbContext.Tags.FirstOrDefault(c => c.Id == id);
        if (tag != null)
        {
            _dbContext.Tags.Remove(tag);
            ((ApplicationDbContext) _dbContext).SaveChangesAsync();
        }
    }
}