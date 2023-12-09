namespace ServiceCatalog.Application.Inrefaces.Base;

public interface IUpdateService<T>
{
    public Task<bool> Update(T entity);
}
