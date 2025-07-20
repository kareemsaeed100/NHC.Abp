using Hangfire;
using NHC.Abp.BackgroundJob.Jobs;
namespace NHC.Abp.BackgroundJob;

public static class HangfireJobRegistrar
{
    public static void Register()
    {
        Hangfire.BackgroundJob.Schedule<SampleJobWrapper>(
            job => job.Execute(),
            TimeSpan.FromMinutes(1)
        );

        RecurringJob.AddOrUpdate<SampleJobWrapper>(
            "SampleJobRecurring",
            job => job.Execute(),
            Cron.Minutely
        );
    }
}
