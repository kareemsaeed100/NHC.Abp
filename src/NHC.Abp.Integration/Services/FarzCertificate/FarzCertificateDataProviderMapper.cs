using Newtonsoft.Json.Linq;
using NHC.Abp.FarzCertificate.Dto;
using NHC.Abp.Integration.Services.FarzCertificate.Dto;

namespace NHC.Abp.Integration.Services.FarzCertificate;

internal interface IFarzCertificateDataProviderMapper
{
    public Task<CertificateUrlDto> MapToCertificateUrlDtoAsync(CertificateResponse result);
    public Dictionary<string, string> BuildCertificateUrlQueryParams(long id);
}

internal class FarzCertificateDataProviderMapper() : IFarzCertificateDataProviderMapper
{
    public Task<CertificateUrlDto> MapToCertificateUrlDtoAsync(CertificateResponse result)
    {
        var certificateData = result.Data switch
        {
            CertificateData cd => cd,
            JObject jObj => jObj.ToObject<CertificateData>(),
            _ => null
        };

        return Task.FromResult(new CertificateUrlDto
        {
            CertificateUrl = certificateData?.CertificateUrl ?? string.Empty
        });
    }

    public Dictionary<string, string> BuildCertificateUrlQueryParams(long id)
    {
        Dictionary<string, string> keyValuePairs = new()
        {
            { FarzConstants.GetCertificateUrl.FilterIdNumber, id.ToString()}
        };
        return keyValuePairs;
    }
}