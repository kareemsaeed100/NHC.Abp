using NHC.Abp.FarzCertificate.AppService.Dto;
using NHC.Abp.FarzCertificate.Dto;

namespace NHC.Abp.FarzCertificate.AppService;

public interface IFarzCertificateAppServiceMapper
{
    public CertificateUrlRequest MapToGetCertificateUrlDto(CertificateUrlRequestDto request);
    public CertificateUrlResponseDto MapToCertificateUrlResponseDto(CertificateUrlDto request);
}
internal class FarzCertificateAppServiceMapper : IFarzCertificateAppServiceMapper
{
    public CertificateUrlRequest MapToGetCertificateUrlDto(CertificateUrlRequestDto request)
    {
        return new CertificateUrlRequest { Id = request.Id };
    }

    public CertificateUrlResponseDto MapToCertificateUrlResponseDto(CertificateUrlDto request)
    {
        return new CertificateUrlResponseDto
        {
            CertificateUrl = request.CertificateUrl
        };
    }
}
