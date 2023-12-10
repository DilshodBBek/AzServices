namespace Notification.Domain.Entities;

public class MassageText
{
    public int Id { get; set; }
    public string Sender {  get; set; }
    public string? Title { get; set; }
    public string Massage { get; set; }

}
