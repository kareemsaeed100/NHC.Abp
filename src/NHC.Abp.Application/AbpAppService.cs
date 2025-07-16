using NHC.Abp.Localization;
using Volo.Abp.Application.Services;

namespace NHC.Abp;

/* Inherit your application services from this class.
 */
public abstract class AbpAppService : ApplicationService
{
    protected AbpAppService()
    {
        LocalizationResource = typeof(AbpResource);
    }
}
