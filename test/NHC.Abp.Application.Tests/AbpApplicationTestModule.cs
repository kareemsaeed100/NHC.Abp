using Volo.Abp.Modularity;

namespace NHC.Abp;

[DependsOn(
    typeof(AbpApplicationModule),
    typeof(AbpDomainTestModule)
)]
public class AbpApplicationTestModule : AbpModule
{

}
