namespace ServiceCatalog.Domain.DTO.FileContent
{
    public class FileContentCreateDTO
    {
        public int Id { get; set; }

        public string FileId { get; set; }=string.Empty; 

        public int BaseId { get; set; }
    }
}
