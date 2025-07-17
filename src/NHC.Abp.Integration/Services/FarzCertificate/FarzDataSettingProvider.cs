using Volo.Abp.Settings;

namespace NHC.Abp.Integration.Services.FarzCertificate;

public class FarzDataSettingProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        context.Add(
            new SettingDefinition(
                FarzConstants.SettingNames.GetCertificateUrl,
                FarzConstants.SettingNames.GetCertificateUrlDefaultValue
            )
        );
    }
}
