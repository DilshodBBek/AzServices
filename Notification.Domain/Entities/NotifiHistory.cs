namespace Notification.Domain.Entities;

public class NotifiHistory
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public DateTime MassageSentTime { get; set; }
    public bool IsSucces { get; set; }
    public int MassageTextId { get; set; }
    public MassageText MassageText { get; set; }

}
