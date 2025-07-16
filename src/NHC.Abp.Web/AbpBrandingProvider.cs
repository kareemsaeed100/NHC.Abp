using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Localization;
using NHC.Abp.Localization;

namespace NHC.Abp.Web;

[Dependency(ReplaceServices = true)]
public class AbpBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<AbpResource> _localizer;

    public AbpBrandingProvider(IStringLocalizer<AbpResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
