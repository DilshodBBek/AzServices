using Notification.Application.Interfaces;
using Notification.Domain.Entities;

namespace Notification.Infrastructure.Service;

public class TelegramBotDbServise : ITelegramBotServise
{
    public Task<TelegramBotEntity> GetUserAsync(TelegramBotEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SendMassageAsync(TelegramBotEntity entity)
    {
        throw new NotImplementedException();
    }
}
