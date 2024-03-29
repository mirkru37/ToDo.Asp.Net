﻿using Domain;

namespace Application.Common.Interfaces;

public interface IRepository<T>
{
    Task<List<T>> GetAll();
    T GetById(string id);
    void Add(T customer);
    void Update(string id, T customer);
    void Delete(string id);
}