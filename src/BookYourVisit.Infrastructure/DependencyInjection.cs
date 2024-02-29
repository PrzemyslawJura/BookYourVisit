using BookYourVisit.Application.Common.Interfaces;
using BookYourVisit.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookYourVisit.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services
            .AddPersistence();
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<IAbsencesRepository, AbsencesRepository>();
        services.AddScoped<IAddressesRepository, AddressesRepository>();
        services.AddScoped<IMessagesRepository, MessagesRepository>();
        services.AddScoped<IReviewsRepository, ReviewsRepository>();
        services.AddScoped<ISalonsRepository, SalonsRepository>();
        services.AddScoped<IServicesRepository, ServicesRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<IVisitsRepository, VisitsRepository>();
        services.AddScoped<IWorkersRepository, WorkersRepository>();
        services.AddScoped<IWorkingSlotsRepository, WorkingSlotsRepository>();
        return services;
    }
}
