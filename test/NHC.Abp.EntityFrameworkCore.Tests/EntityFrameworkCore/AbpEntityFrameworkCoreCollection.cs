using Xunit;

namespace NHC.Abp.EntityFrameworkCore;

[CollectionDefinition(AbpTestConsts.CollectionDefinitionName)]
public class AbpEntityFrameworkCoreCollection : ICollectionFixture<AbpEntityFrameworkCoreFixture>
{

}
