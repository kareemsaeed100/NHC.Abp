using Microsoft.Extensions.Logging;
using System;
using Volo.Abp.Application.Services;

namespace NHC.Abp.SampleJob
{
    public class SampleJobAppService : ApplicationService, ISampleJobAppService
    {
        private readonly ILogger<SampleJobAppService> _logger;

        public SampleJobAppService(ILogger<SampleJobAppService> logger)
        {
            _logger = logger;
        }

        public void DoWork()
        {
            _logger.LogInformation("Sample Hangfire job executed at: " + DateTime.Now);
        }
    }

}
