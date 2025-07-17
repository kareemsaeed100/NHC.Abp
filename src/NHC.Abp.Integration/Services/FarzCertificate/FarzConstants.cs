namespace NHC.Abp.Integration.Services.FarzCertificate;

internal class FarzConstants
{
    internal static class SettingNames
    {
        public const string GroupName = "Farz";

        public const string GetCertificateUrl = $"{GroupName}.{nameof(GetCertificateUrl)}";
        public const string GetCertificateUrlDefaultValue = "v1/subdivision/Certificate";
    }

    internal static class GetCertificateUrl
    {
        public const string FilterIdNumber = "id";
    }

}
