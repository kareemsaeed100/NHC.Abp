using NHC.Abp.SampleJob;

namespace NHC.Abp.BackgroundJob.Jobs;

public class SampleJobWrapper
{
    private readonly ISampleJobAppService _sampleJobAppService;

    public SampleJobWrapper(ISampleJobAppService sampleJobAppService)
    {
        _sampleJobAppService = sampleJobAppService;
    }

    public void Execute()
    {
        _sampleJobAppService.DoWork();
    }
}
