using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TestProject.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class TestProjectMigrationsDbContextFactory : IDesignTimeDbContextFactory<TestProjectMigrationsDbContext>
    {
        public TestProjectMigrationsDbContext CreateDbContext(string[] args)
        {
            TestProjectEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<TestProjectMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new TestProjectMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
