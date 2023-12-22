using Microsoft.EntityFrameworkCore;
using SP.Application.Services;
using SP.Domain.Entities.Categories;
using SP.Infrastructure.DataAccess;

namespace SP.Infrastructure.Services;

public class CategoryService : ICategoryService<CategoryEntity>
{
    private readonly StadiumDbContext _context;

    public CategoryService(StadiumDbContext context)
    {
        _context = context;
    }

    public async Task<CategoryEntity> CreateAsync(CategoryEntity category)
    {
        if (_context.Categories.Where(x => x.CategoryNameUz == category.CategoryNameUz).Count() is 0
            && _context.Categories.Where(x => x.CategoryNameRu == category.CategoryNameRu).Count() is 0
            && _context.Categories.Where(x => x.CategoryNameEn == category.CategoryNameEn).Count() is 0)
        {
            await _context.AddAsync(category);
            _context?.SaveChangesAsync();
            return category;
        }
        else
        {
            return null;
        }
    }

    public async Task<bool> Delete(int id)
    {
        CategoryEntity deleteCategories = await _context.Categories.FirstAsync(x => x.CategoryId == id);
        if (deleteCategories != null)
        {
            _context.Categories.Remove(deleteCategories);
            _context.SaveChangesAsync();
            return true;
        }
        else
        {
            return false;
        }
    }

    public IEnumerable<CategoryEntity> GetAll()
    {
        return _context.Categories.ToList();
    }

    public CategoryEntity GetById(int id)
    {
        var getCategories = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
        if (getCategories != null)
            return getCategories;
        else
            return null;
    }

    public async Task<bool> Update(CategoryEntity bookingStatus)
    {
        var updateCategory = _context.Categories.FirstOrDefault(x => x.CategoryId == bookingStatus.CategoryId);
        if (updateCategory != null)
        {
            updateCategory.CategoryNameUz = bookingStatus.CategoryNameUz;
            updateCategory.CategoryNameRu = bookingStatus.CategoryNameRu;
            updateCategory.CategoryNameEn = bookingStatus.CategoryNameEn;
            _context.Categories.Update(updateCategory);
            _context.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }
}
