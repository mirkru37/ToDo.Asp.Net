﻿using Application.Common.Interfaces;
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
    
    public IEnumerable<UserEntity> GetAll()
    {
        return _dbContext.Users.ToList();
    }

    public UserEntity GetById(int id)
    {
        return _dbContext.Users.FirstOrDefault(c => c.Id == id);
    }

    public void Add(UserEntity user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChangesAsync();
    }

    public void Update(UserEntity user)
    {
        _dbContext.Users.Entry(user).State = EntityState.Modified;
        _dbContext.SaveChangesAsync();
    }

    public void Delete(int id)
    {
        var user = _dbContext.Users.FirstOrDefault(c => c.Id == id);
        if (user != null)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChangesAsync();
        }
    }
}