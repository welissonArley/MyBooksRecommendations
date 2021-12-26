using Microsoft.Extensions.DependencyInjection;
using MyBooksRecommendations.Domain.Repository;
using MyBooksRecommendations.Infrastructure.DataAccess.Repositories;

namespace MyBooksRecommendations.Infrastructure
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBookReadOnlyRepository, BookRepository>();

            return services;
        }
    }
}
