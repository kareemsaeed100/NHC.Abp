using Microsoft.AspNetCore.Builder;
using NHC.Abp;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("NHC.Abp.Web.csproj"); 
await builder.RunAbpModuleAsync<AbpWebTestModule>(applicationName: "NHC.Abp.Web");

public partial class Program
{
}
