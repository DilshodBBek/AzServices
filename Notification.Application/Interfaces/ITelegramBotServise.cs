using Notification.Application.Repositories;
using Notification.Domain.Entities;

namespace Notification.Application.Interfaces;

public interface ITelegramBotServise : IRepository<TelegramBotEntity>
{
}
