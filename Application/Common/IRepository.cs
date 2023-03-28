using Domain;

namespace Application.Common.Interfaces;

public interface IRepository<T>
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Add(T customer);
    void Update(T customer);
    void Delete(int id);
}