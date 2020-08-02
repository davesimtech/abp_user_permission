using TestProject.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace TestProject
{
    [DependsOn(
        typeof(TestProjectEntityFrameworkCoreTestModule)
        )]
    public class TestProjectDomainTestModule : AbpModule
    {

    }
}