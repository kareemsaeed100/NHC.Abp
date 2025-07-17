using System;
using Volo.Abp.Application.Dtos;

namespace NHC.Abp.Notifications
;
public class NotificationRequestDto : PagedResultRequestDto
{
}

public class NotificationDto
{
    public long NotificationId { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public bool IsRead { get; set; }
    public DateTimeOffset NotificationDateTime { get; set; }
}
