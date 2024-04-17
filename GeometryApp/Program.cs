using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;

class Program
{
    static void Main(string[] args)
    {
        var featureManagement = new Dictionary<string, string>
        {
            { "FeatureManagement:Square", "true" },
            { "FeatureManagement:Rectangle", "false" },
            { "FeatureManagement:Triangle", "true" }
        };

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(featureManagement)
            .Build();

        var services = new ServiceCollection();
        services.AddFeatureManagement(configuration);
        var serviceProvider = services.BuildServiceProvider();

        
    }
}
