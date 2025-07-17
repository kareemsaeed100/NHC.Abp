using Microsoft.AspNetCore.Mvc;
using NHC.Abp;
using NHC.Abp.Notifications;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Users;

namespace NHC.Boilerplate.Notifications.Dto;

[Route("api/notifications")]
public class NotificationAppService(NotificationManager _notificationManager, ICurrentUser _currentUser) : AbpAppServiceBase
{

    [HttpGet("all")]
    public async Task<PagedResultDto<NotificationDto>> GetAllAsync(NotificationRequestDto request)
    {
        long currentUser = Convert.ToInt64(_currentUser.Id.Value);

        var allNotifications = await _notificationManager.GetUserNotificationsAsync(currentUser);

        var pagedNotifications = allNotifications
            .Skip(request.SkipCount)
            .Take(request.MaxResultCount)
            .ToList();

        var notificationDtos = pagedNotifications
            .Select(notification => new NotificationDto
            {
                NotificationId = notification.Id,
                Title = notification.TitleAr,
                Message = notification.MessageAr,
                IsRead = notification.IsRead,
                NotificationDateTime = notification.NotificationDateTime
            })
            .ToList();

        return new PagedResultDto<NotificationDto>
        {
            Items = notificationDtos,
            TotalCount = allNotifications.Count
        };
    }

    [HttpGet("count")]
    public async Task<int> GetCountAsync()
    {
        long currentUser = Convert.ToInt64(_currentUser.Id.Value);
        return await _notificationManager.GetUnreadCountAsync(currentUser);
    }

    [HttpPost("mark-read/{notificationId}")]
    public async Task<bool> MarkAsReadAsync(long notificationId)
    {
        long currentUser = Convert.ToInt64(_currentUser.Id.Value);
        return await _notificationManager.MarkAsReadAsync(notificationId, currentUser);
    }

    [HttpPost("{notificationId}")]
    public async Task<bool> DeleteAsync(long notificationId)
    {
        long currentUser = Convert.ToInt64(_currentUser.Id.Value);
        return await _notificationManager.DeleteAsync(notificationId, currentUser);
    }
}
