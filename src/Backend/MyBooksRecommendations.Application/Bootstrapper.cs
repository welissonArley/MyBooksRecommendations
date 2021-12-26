using Microsoft.Extensions.DependencyInjection;
using MyBooksRecommendations.Application.UseCases.Book.Get;

namespace MyBooksRecommendations.Application
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IGetBookUseCase, GetBookUseCase>();

            return services;
        }
    }
}
