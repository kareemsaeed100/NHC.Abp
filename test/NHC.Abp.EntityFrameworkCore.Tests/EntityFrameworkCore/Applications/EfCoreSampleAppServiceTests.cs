using NHC.Abp.Samples;
using Xunit;

namespace NHC.Abp.EntityFrameworkCore.Applications;

[Collection(AbpTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AbpEntityFrameworkCoreTestModule>
{

}
