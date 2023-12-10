using ServiceCatalog.Domain.Entity.Common;
namespace ServiceCatalog.Domain.Entity.File;
public class FileContent
{
	public int Id { get; set; }

	public string FileId { get; set; }

	public int BaseId { get; set; }
	public Base Base { get; set; }


}
