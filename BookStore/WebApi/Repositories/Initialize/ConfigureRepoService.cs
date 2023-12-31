using WebApi.Repositories;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureRepoService
{
    public static void AddRepoServices(this IServiceCollection services)
    {
        GenreRepository.Initialize();
        BookRepository.Initialize();
        AuthorRepository.Initialize();
        BookAuthorRepository.Initialize();

        Console.WriteLine("DB Initialize Complted.");
    }
}
