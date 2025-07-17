using Volo.Abp.Settings;

namespace NHC.Abp.Integration.NHCIntegrationClient;


public class NHClientSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        context.Add(new SettingDefinition(
            NhcClientSetting.BaseUrl,
            "https://integration-gw.housingapps.sa/nhc/dev/"
        ));

        context.Add(new SettingDefinition(
            NhcClientSetting.ClientId,
            NhcClientSetting.ClientIdDefaultValue
        ));

        context.Add(new SettingDefinition(
            NhcClientSetting.ClientSecret,
            NhcClientSetting.ClientSecretDefaultValue
        ));

        context.Add(new SettingDefinition(
            NhcClientSetting.RefId,
            "12"
        ));
    }
}
