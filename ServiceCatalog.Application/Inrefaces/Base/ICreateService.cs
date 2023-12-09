namespace ServiceCatalog.Application.Inrefaces.Base;

public interface ICreateService<T>
{
    public Task<bool> Create(T obj);
}
