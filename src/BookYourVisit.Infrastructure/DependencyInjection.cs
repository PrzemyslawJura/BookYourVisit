using BookYourVisit.Application.Common.Interfaces;
using BookYourVisit.Infrastructure.Common.Persistence;
using BookYourVisit.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookYourVisit.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddPersistence(configuration);
    }
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BookYourVisitDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
       // services.AddDbContext<BookYourVisitDbContext>(options =>
        //    options.UseSqlServer(("Data Source = BookYourVisit.db"),
         //   b => b.MigrationsAssembly("BookYourVisit.Infrastructure")));

        services.AddScoped<IAbsencesRepository, AbsencesRepository>();
        //services.AddScoped<IAddressesRepository, AddressesRepository>();
        //services.AddScoped<IMessagesRepository, MessagesRepository>();
        //services.AddScoped<IReviewsRepository, ReviewsRepository>();
        //services.AddScoped<ISalonsRepository, SalonsRepository>();
        //services.AddScoped<IServicesRepository, ServicesRepository>();
        //services.AddScoped<IUsersRepository, UsersRepository>();
        //services.AddScoped<IVisitsRepository, VisitsRepository>();
        //services.AddScoped<IWorkersRepository, WorkersRepository>();
        //services.AddScoped<IWorkingSlotsRepository, WorkingSlotsRepository>();
        return services;
    }
}
