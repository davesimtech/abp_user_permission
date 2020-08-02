using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace TestProject.EntityFrameworkCore
{
    public static class TestProjectDbContextModelCreatingExtensions
    {
        public static void ConfigureTestProject(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(TestProjectConsts.DbTablePrefix + "YourEntities", TestProjectConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}