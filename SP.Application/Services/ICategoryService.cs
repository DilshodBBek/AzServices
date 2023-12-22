using SP.Application.Repository;
using SP.Domain.Entities.Categories;

namespace SP.Application.Services;

public interface ICategoryService<T> : IRepository<CategoryEntity>
{
}
