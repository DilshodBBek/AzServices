namespace ServiceCatalog.Application.Inrefaces.Base;

public interface IDeleteService
{
    public Task<bool> Delete(int Id);
}
