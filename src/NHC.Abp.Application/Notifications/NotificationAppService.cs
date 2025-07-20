using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NHC.Abp.Notifications;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace NHC.Boilerplate.Notifications.Dto;

[Authorize]
[Route("api/notifications")]
public class NotificationAppService : AbpAppServiceBase
{
    private readonly NotificationManager _notificationManager;

    public NotificationAppService(NotificationManager notificationManager)
    {
        _notificationManager = notificationManager;
    }


    [HttpGet("all")]
    public async Task<PagedResultDto<NotificationDto>> GetAllAsync(NotificationRequestDto request)
    {
        var currentUser = await GetCurrentUserAsync();

        var allNotifications = await _notificationManager.GetUserNotificationsAsync(currentUser.Id);

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
        var currentUser = await GetCurrentUserAsync();
        return await _notificationManager.GetUnreadCountAsync(currentUser.Id);
    }

    [HttpPost("mark-read/{notificationId}")]
    public async Task<bool> MarkAsReadAsync(long notificationId)
    {
        var currentUser = await GetCurrentUserAsync();
        return await _notificationManager.MarkAsReadAsync(notificationId, currentUser.Id);
    }

    [HttpPost("{notificationId}")]
    public async Task<bool> DeleteAsync(long notificationId)
    {
        var currentUser = await GetCurrentUserAsync();
        return await _notificationManager.DeleteAsync(notificationId, currentUser.Id);
    }
}
