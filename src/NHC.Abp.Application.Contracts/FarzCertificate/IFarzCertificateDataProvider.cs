using System.Threading.Tasks;

namespace NHC.Abp.FarzCertificate.Dto;
public interface IFarzCertificateDataProvider
{
    Task<CertificateUrlDto> GetCertificateUrlAsync(CertificateUrlRequest request);
}


