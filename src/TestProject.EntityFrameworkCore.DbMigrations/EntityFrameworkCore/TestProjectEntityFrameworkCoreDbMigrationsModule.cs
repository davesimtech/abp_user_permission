using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace TestProject.EntityFrameworkCore
{
    [DependsOn(
        typeof(TestProjectEntityFrameworkCoreModule)
        )]
    public class TestProjectEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<TestProjectMigrationsDbContext>();
        }
    }
}
