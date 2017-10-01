namespace Mc.AspNetCore
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Configuration;
    using System.IO;
    using Mc.AspNetCore.Model;
    using Microsoft.Extensions.Logging;

    public class Startup
    {
        public IConfiguration Configuration;

        public Startup()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables()
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .Configure<Data>(Configuration.GetSection(nameof(Data)))
                .AddMvcCore()
                .AddJsonFormatters();
        }

        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            app.UseMvc();
            loggerFactory.AddDebug();
        }
    }
}
