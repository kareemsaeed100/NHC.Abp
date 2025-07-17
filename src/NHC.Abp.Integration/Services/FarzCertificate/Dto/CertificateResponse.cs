using Newtonsoft.Json;

namespace NHC.Abp.Integration.Services.FarzCertificate.Dto;

public record CertificateResponse
{
    [JsonProperty("success")]
    public bool Success { get; set; }
    [JsonProperty("message")]
    public string Message { get; set; }
    [JsonProperty("data")]
    public object Data { get; set; }
}

public record CertificateData
{
    [JsonProperty("Certificate_Url")]
    public string CertificateUrl { get; set; }
}
