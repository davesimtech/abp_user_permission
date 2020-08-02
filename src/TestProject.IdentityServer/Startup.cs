using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TestProject
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<TestProjectIdentityServerModule>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.InitializeApplication();
        }
    }
}
