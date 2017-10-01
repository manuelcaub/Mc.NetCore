namespace Mc.NetCore
{
    using Mc.NetCore.Abstractions;
    using Mc.NetCore.Services;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.IO;

    public class Program
    {
        public static void Main()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<Program>()
                .Build();

            var services = new ServiceCollection();
            services.AddSingleton<IValidator, NumberValidator>();
            var serviceProvider = services.BuildServiceProvider();
            var validator = serviceProvider.GetService<IValidator>();
            Console.WriteLine($"The validation result is {validator.Validate("1234")}");
            Console.Read();
        }
    }
}
