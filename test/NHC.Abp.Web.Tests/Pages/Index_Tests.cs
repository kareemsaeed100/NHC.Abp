using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace NHC.Abp.Pages;

[Collection(AbpTestConsts.CollectionDefinitionName)]
public class Index_Tests : AbpWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
