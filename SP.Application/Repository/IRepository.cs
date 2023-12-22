namespace SP.Application.Repository;

public interface IRepository<T>
{
    Task<T> CreateAsync(T location);
    Task<bool> Update(T location);
    Task<bool> Delete(int id);
    public T GetById(int id);
    public IEnumerable<T> GetAll();
}