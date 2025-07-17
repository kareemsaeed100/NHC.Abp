namespace NHC.Abp.FarzCertificate.AppService.Dto;

public record CertificateUrlRequestDto
{
    public long Id { get; set; }
}

public record CertificateUrlResponseDto
{
    public string CertificateUrl { get; set; }
}

