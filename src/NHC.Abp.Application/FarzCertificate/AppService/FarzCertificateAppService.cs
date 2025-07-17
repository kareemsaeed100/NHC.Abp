using Microsoft.AspNetCore.Mvc;
using NHC.Abp.FarzCertificate.AppService.Dto;
using NHC.Abp.FarzCertificate.Dto;
using System.Threading.Tasks;

namespace NHC.Abp.FarzCertificate.AppService;

//[AbpAuthorize]
public class FarzCertificateAppService(IFarzCertificateDataProvider provider, IFarzCertificateAppServiceMapper mapper) : AbpAppServiceBase, IFarzCertificateAppService
{
    [HttpGet]
    public async Task<CertificateUrlResponseDto> GetCertificateUrl(CertificateUrlRequestDto request)
    {
        var mapRequest = mapper.MapToGetCertificateUrlDto(request);
        var result = await provider.GetCertificateUrlAsync(mapRequest);
        return mapper.MapToCertificateUrlResponseDto(result);
    }
}
