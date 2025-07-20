using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using NHC.Abp.Localization;
using NHC.Abp.Notifications.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace NHC.Abp.Notifications;
public class NotificationManager : DomainService, ITransientDependency
{
    private readonly IAbpLazyServiceProvider _lazyServiceProvider;
    private readonly IRepository<Notification> _notificationRepository;
    private readonly IStringLocalizer<AbpResource> _localizer;
    public NotificationManager(IAbpLazyServiceProvider lazyServiceProvider)
    {
        _lazyServiceProvider = lazyServiceProvider;
        _localizer = _lazyServiceProvider.LazyGetRequiredService<IStringLocalizer<AbpResource>>();
        _notificationRepository = _lazyServiceProvider.LazyGetRequiredService<IRepository<Notification>>();

    }

    public async Task<Notification> CreateNotificationAsync(Guid userId, string titleAr, string titleEn, string messageAr, string messageEn, NotificationType notificationType)
    {
        var notification = Notification.Create(userId, titleAr, titleEn, messageAr, messageEn, notificationType, DateTime.Now);
        await _notificationRepository.InsertAsync(notification);

        return notification;
    }

    public async Task<int> GetUnreadCountAsync(Guid userId)
    {
        return await _notificationRepository.CountAsync(x =>
            x.UserId == userId && !x.IsRead && !x.IsDeleted
        );
    }

    public async Task<bool> MarkAsReadAsync(long notificationId, Guid userId)
    {
        var notification = await _notificationRepository.FirstOrDefaultAsync(x => x.Id == notificationId && x.UserId == userId);

        if (notification == null)
            throw new UserFriendlyException(_localizer["InvalidNotificationNumber"]);

        notification.MarkAsRead();
        return true;
    }

    public async Task<bool> DeleteAsync(long notificationId, Guid userId)
    {
        var notification = await _notificationRepository.FirstOrDefaultAsync(x => x.Id == notificationId && x.UserId == userId);

        if (notification == null)
            throw new UserFriendlyException(_localizer["InvalidNotificationNumber"]);

        await _notificationRepository.DeleteAsync(notification);
        return true;
    }

    public async Task<List<Notification>> GetUserNotificationsAsync(Guid userId)
    {
        var query = await _notificationRepository.GetQueryableAsync();

        return await query
            .Where(x => x.UserId == userId && !x.IsDeleted)
            .OrderByDescending(x => x.CreationTime)
            .ToListAsync();
    }
}
