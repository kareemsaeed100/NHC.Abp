using Microsoft.Extensions.DependencyInjection;
using NHC.Abp.FarzCertificate.Dto;
using NHC.Abp.Integration.NHCIntegrationClient;
using NHC.Abp.Integration.Services.FarzCertificate;
using Volo.Abp.Modularity;
namespace NHC.Abp.Integration;

public class NHCAbpIntegrationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var services = context.Services;

        services.AddSingleton<INHClient, NHCClient>();

        services.AddHttpClient();
        services.AddScoped<IFarzCertificateDataProvider, FarzCertificateIntegrationProvider>();
        services.AddScoped<IFarzCertificateDataProviderMapper, FarzCertificateDataProviderMapper>();
    }
}
