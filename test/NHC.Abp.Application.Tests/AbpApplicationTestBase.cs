using Volo.Abp.Modularity;

namespace NHC.Abp;

public abstract class AbpApplicationTestBase<TStartupModule> : AbpTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
