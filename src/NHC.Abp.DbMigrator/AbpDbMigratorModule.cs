using NHC.Abp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace NHC.Abp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpEntityFrameworkCoreModule),
    typeof(AbpApplicationContractsModule)
)]
public class AbpDbMigratorModule : AbpModule
{
}
