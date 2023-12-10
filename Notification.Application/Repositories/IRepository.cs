namespace Notification.Application.Repositories;

public interface IRepository<T>
{
    public Task<T> GetUserAsync(T entity);
    public Task<bool> SendMassageAsync(T entity);
}
