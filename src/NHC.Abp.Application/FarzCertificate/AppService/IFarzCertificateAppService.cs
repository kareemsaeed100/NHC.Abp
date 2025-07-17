using NHC.Abp.FarzCertificate.AppService.Dto;
using System.Threading.Tasks;

namespace NHC.Abp.FarzCertificate.AppService;

public interface IFarzCertificateAppService
{
    Task<CertificateUrlResponseDto> GetCertificateUrl(CertificateUrlRequestDto request);
}
