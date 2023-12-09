namespace ServiceCatalog.Application.Inrefaces.Base;

public interface IGetByIdService<T>
{
    public Task<T> GetById(int Id);
}
