namespace ServiceCatalog.Application.Inrefaces.Base;

public interface IGetAllService<T>
{
    public Task<IEnumerable<T>> GetAll();
}
