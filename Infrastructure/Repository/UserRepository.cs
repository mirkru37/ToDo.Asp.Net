using Application.Common.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class UserRepository : IRepository<UserEntity>
{
    private readonly IApplicationDBContext _dbContext;
    
    public UserRepository(IApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task<List<UserEntity>> GetAll()
    {
        return _dbContext.Users.ToListAsync();
    }

    public UserEntity GetById(string id)
    {
        return _dbContext.Users.FirstOrDefault(c => c.Id == id);
    }

    public void Add(UserEntity user)
    {
        _dbContext.Users.Add(user);
        ((ApplicationDbContext) _dbContext).SaveChangesAsync();
    }

    public void Update(string id, UserEntity user)
    {
        _dbContext.Users.Entry(user).State = EntityState.Modified;
        ((ApplicationDbContext) _dbContext).SaveChangesAsync();
    }

    public void Delete(string id)
    {
        var user = _dbContext.Users.FirstOrDefault(c => c.Id == id);
        if (user != null)
        {
            _dbContext.Users.Remove(user);
            ((ApplicationDbContext) _dbContext).SaveChanges();
        }
    }
}