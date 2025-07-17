using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NHC.Abp.Notifications;

namespace NHC.Abp.EntityFrameworkCore.Configuration;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.ToTable("Notifications");

        builder.HasKey(x => x.Id);


        builder.Property(u => u.TitleAr);
        builder.Property(u => u.TitleEn);

        builder.Property(u => u.MessageAr);
        builder.Property(u => u.MessageEn);

        builder.Property(x => x.NotificationType)
            .IsRequired().HasConversion<string>();

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.Property(x => x.IsRead)
            .IsRequired();

        builder.HasIndex(x => new { x.UserId, x.IsRead });
    }
}
