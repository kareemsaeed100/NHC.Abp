using Microsoft.Extensions.Logging;
using NHC.Abp.FarzCertificate.Dto;
using NHC.Abp.Integration.Exceptions;
using NHC.Abp.Integration.NHCIntegrationClient;
using NHC.Abp.Integration.Services.FarzCertificate.Dto;
using Volo.Abp;
using Volo.Abp.Settings;
namespace NHC.Abp.Integration.Services.FarzCertificate;

internal class FarzCertificateIntegrationProvider(INHClient nhcClient, ISettingProvider settingProvider,
   IFarzCertificateDataProviderMapper factory) : NHCBaseIntegrationServiceBase, IFarzCertificateDataProvider
{
    public async Task<CertificateUrlDto> GetCertificateUrlAsync(CertificateUrlRequest request)
    {
        try
        {
            var uri = await settingProvider.GetOrNullAsync(FarzConstants.SettingNames.GetCertificateUrl);

            var queryParam = factory.BuildCertificateUrlQueryParams(request.Id);

            var response = await nhcClient.GetAsync<CertificateResponse>(uri, urlParam: queryParam);

            if (response.Body != null && !response.Body.Success)
                throw new UserFriendlyException("CertificateFailed");
            return await factory.MapToCertificateUrlDtoAsync(response.Body);
        }
        catch (ClientCommunionException ex)
        {
            Logger.LogError(ex, "NHClientCommunionException While Executing FarzContractsProvider.GetCertificateUrl{Message}", ex.Message);
            throw new UserFriendlyException("CertificateFailed");
        }
    }
}
