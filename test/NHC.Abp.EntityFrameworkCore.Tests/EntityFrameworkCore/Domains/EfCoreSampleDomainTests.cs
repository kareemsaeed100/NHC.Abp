using NHC.Abp.Samples;
using Xunit;

namespace NHC.Abp.EntityFrameworkCore.Domains;

[Collection(AbpTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AbpEntityFrameworkCoreTestModule>
{

}
