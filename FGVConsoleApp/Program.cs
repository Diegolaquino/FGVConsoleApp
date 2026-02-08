using FGVConsoleApp.Model;
using FGVConsoleApp.Options;
using FGVConsoleApp.Seed;
using FGVConsoleApp.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

class Program
{
    static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var services = new ServiceCollection();

        services.AddSingleton<IConfiguration>(configuration);

        // Opção 1: Ler diretamente do configuration e registrar como singleton
        var sortingOptions = configuration.GetSection("Sorting").Get<SortingOptions>();
        services.AddSingleton(sortingOptions);

        services.AddScoped<IBooksOrderer>(sp =>
        {
            var options = sp.GetRequiredService<SortingOptions>();
            return new BooksOrderer(options.Rules);
        });

        using var serviceProvider = services.BuildServiceProvider();

        Run(serviceProvider);
    }

    static void Run(IServiceProvider serviceProvider)
    {
        var orderer = serviceProvider.GetRequiredService<IBooksOrderer>();
        var livros = Faker.CriarConjuntoPadraoDeLivros();
        var resultado = orderer.Order(livros);

        foreach (var livro in resultado)
        {
            Console.WriteLine($"{livro.Title} - {livro.AuthorName} ({livro.EditionYear})");
        }
    }
}