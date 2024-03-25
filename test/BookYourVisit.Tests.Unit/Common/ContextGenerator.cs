using BookYourVisit.Domain.Salons;
using BookYourVisit.Domain.Services;
using BookYourVisit.Domain.Workers;
using BookYourVisit.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookYourVisit.Tests.Unit.Common;
public static class ContextGenerator
{
    public static BookYourVisitDbContext Generate()
    {
        var optionsBuilder = new DbContextOptionsBuilder<BookYourVisitDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString());
        return new BookYourVisitDbContext(optionsBuilder.Options);
    }

    public static async void Add_SalonWithRelated(BookYourVisitDbContext context)
    {
        context.Salons.Add(salonWithStaticId);
        context.Addresses.Add(addressWithStaticId);
        context.Workers.Add(workerWithStaticId);
        context.Services.Add(serviceWithStaticId);
        await context.CommitChangesAsync();
    }

    public static Guid salonId = new Guid("5fb7097c-335c-4d07-b4fd-000004e2d28c");
    public static Guid addressId = new Guid("022b5704-3f12-4033-b881-c6b6582f12c1");
    public static Guid workerId = new Guid("2715d3d7-9cf3-47b6-890d-cf982c5b5b9d");
    public static Guid serviceId = new Guid("23b75af9-7618-4e41-9328-8b51ca320bc6");

    public static Salon salonWithStaticId = new Salon(
            "Salon Szybcy i obcięci",
            "Description",
            "mainPhoto",
            "photos",
            "234543342",
            "szybcyiobcieci@email.com",
            (float)88.23,
            (float)23.45,
            salonId);

    public static Address addressWithStaticId = new Address(
            "Polska",
            "Opole",
            "Piastowska",
            "2/33",
            "45-555",
            salonId,
            addressId);

    public static Worker workerWithStaticId = new Worker(
            "Jan",
            "Kowalski",
            "jankowalski@email.com",
            "466872359",
            salonId,
            workerId);

    public static Service serviceWithStaticId = new Service(
            "Strzyżenie zwykłe",
            "Description",
            50,
            "PLN",
            45,
            workerId,
            serviceId);
}
