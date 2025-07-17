namespace NHC.Abp.Integration.Services.FarzCertificate.Dto;

public record SubdivisionCertificateResponse
{
    public string CertificateNumber { get; set; }
    public string FarzReportNumber { get; set; }
    public string UnitTypeId { get; set; }
    public string UnitTypeName { get; set; }
    public string UnitArea { get; set; }
    public string FarzCertificateFile { get; set; }
    public int? TotalCount { get; set; }
}

