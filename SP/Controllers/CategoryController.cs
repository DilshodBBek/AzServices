using Microsoft.AspNetCore.Mvc;
using SP.Application.Services;
using SP.Domain.Entities.Categories;
using SP.Domain.Models;

namespace SP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService<CategoryEntity> _categoryService;
        private readonly ILogger<DistrictController> _logger;

        public CategoryController(ICategoryService<CategoryEntity> _categoryService, ILogger<DistrictController> logger)
        {
            _categoryService = _categoryService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ResponseModel<CategoryEntity>> CreateAsync(CategoryEntity categories)
        {
            Task<CategoryEntity> createdBooking = _categoryService.CreateAsync(categories);
            return new(categories);
        }

        [HttpGet]
        public async Task<ResponseModel<IEnumerable<CategoryEntity>>> GetAll()
        {
            IEnumerable<CategoryEntity> getAllcategories = _categoryService.GetAll();
            return new(getAllcategories);
        }

        [HttpPut]
        public async Task<ResponseModel<bool>> Update(int id, [FromBody] CategoryEntity category)
        {
            bool mappedCategories = await _categoryService.Update(category);
            return new(mappedCategories);
        }

        [HttpDelete]
        public async Task<ResponseModel<bool>> DeleteAsync(int id)
        {
            try
            {
                bool deleteId = await _categoryService.Delete(id);
                string s = deleteId ? "Delete" : "There is no Id";
                return new(s);
            }
            catch
            {
                return new(false);
            }
        }

        [HttpGet]
        public CategoryEntity GetById(int id)
        {
            var getById = _categoryService.GetById(id);
            return getById;
        }
    }
}
