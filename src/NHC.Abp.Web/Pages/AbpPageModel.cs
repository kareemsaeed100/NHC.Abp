using NHC.Abp.Localization;

namespace NHC.Abp.Web.Pages;

public abstract class AbpPageModel : Volo.Abp.AspNetCore.Mvc.UI.RazorPages.AbpPageModel
{
    protected AbpPageModel()
    {
        LocalizationResourceType = typeof(AbpResource);
    }
}
