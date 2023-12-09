namespace SP.Application.Repository;

public interface IRepository<T>
{
    Task<bool> CreateAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(int Id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int Id);
}