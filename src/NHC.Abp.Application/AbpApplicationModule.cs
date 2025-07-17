using Microsoft.Extensions.DependencyInjection;
using NHC.Abp.FarzCertificate.AppService;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace NHC.Abp;

[DependsOn(
    typeof(AbpDomainModule),
    typeof(AbpApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpAccountApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class AbpApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var services = context.Services;

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<AbpApplicationModule>();
        });
        services.AddSingleton<IFarzCertificateAppServiceMapper, FarzCertificateAppServiceMapper>();

    }
}
