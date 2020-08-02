using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace TestProject.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(TestProjectHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class TestProjectConsoleApiClientModule : AbpModule
    {
        
    }
}
