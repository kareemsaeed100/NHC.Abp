using Volo.Abp.Modularity;

namespace NHC.Abp;

[DependsOn(
    typeof(AbpDomainModule),
    typeof(AbpTestBaseModule)
)]
public class AbpDomainTestModule : AbpModule
{

}
