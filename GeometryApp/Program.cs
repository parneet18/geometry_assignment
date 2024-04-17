using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;

class Program
{
    static async Task Main(string[] args)
    {
        var featureManagement = new Dictionary<string, string>
        {
            { "FeatureManagement:Square", "true" },
            { "FeatureManagement:Rectangle", "true" },
            { "FeatureManagement:Triangle", "false" }
        };

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(featureManagement)
            .Build();

        var services = new ServiceCollection();
        services.AddFeatureManagement(configuration);
        var serviceProvider = services.BuildServiceProvider();

        var featureManager = serviceProvider.GetRequiredService<IFeatureManager>();

        Console.WriteLine("Enter the side length for the shape:");
        if (double.TryParse(Console.ReadLine(), out double sideLength))
        {
            if (await featureManager.IsEnabledAsync("Square"))
            {
                Console.WriteLine($"Square area with side length {sideLength}: {sideLength * sideLength}");
            }

            if (await featureManager.IsEnabledAsync("Rectangle"))
            {
                Console.WriteLine("Enter the width for the rectangle:");
                if (double.TryParse(Console.ReadLine(), out double width))
                {
                    Console.WriteLine($"Rectangle area with side length {sideLength} and width {width}: {sideLength * width}");
                }
            }

            if (await featureManager.IsEnabledAsync("Triangle"))
            {
                Console.WriteLine("Enter the lengths of the other two sides for the triangle:");
                if (double.TryParse(Console.ReadLine(), out double side2) && double.TryParse(Console.ReadLine(), out double side3))
                {
                    var semiPerimeter = (sideLength + side2 + side3) / 2;
                    var area = Math.Sqrt(semiPerimeter * (semiPerimeter - sideLength) * (semiPerimeter - side2) * (semiPerimeter - side3));
                    Console.WriteLine($"Triangle area with side lengths {sideLength}, {side2}, {side3}: {area}");
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
}
