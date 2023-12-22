using System.ComponentModel.DataAnnotations;

namespace SP.Domain.Entities.Categories;

public class CategoryEntity
{
    [Key]
    public int CategoryId { get; set; }
    public string? CategoryNameUz { get; set; }
    public string? CategoryNameRu { get; set; }
    public string? CategoryNameEn { get; set; }
}
