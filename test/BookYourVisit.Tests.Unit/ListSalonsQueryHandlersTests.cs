using BookYourVisit.Application.Common.Interfaces;
using BookYourVisit.Application.Queries.Salons.ListSalons;
using BookYourVisit.Infrastructure.Common.Persistence;
using BookYourVisit.Infrastructure.Repositories;
using BookYourVisit.Tests.Unit.Common;
using FluentAssertions;

namespace BookYourVisit.Tests.Unit;

public class ListSalonsQueryHandlersTests
{
    private readonly ISalonsRepository salonsRepository;
    private readonly BookYourVisitDbContext context;


    public ListSalonsQueryHandlersTests()
    {
        context = ContextGenerator.Generate();
        salonsRepository = new SalonsRepository(context);
    }

    [Fact]
    public async Task Handler_ShouldReturnErrorSalonsNotFound_WhenNoSalonsExist()
    {
        // Arrange
        ListSalonsQueryHandler _sut;
        _sut = new ListSalonsQueryHandler(salonsRepository);

        //// Act
        var result = await _sut.Handle(new ListSalonsQuery(1, 5), default);

        //// Assert
        result.FirstError.Description.Should().Be("Salons not found");
    }

    [Fact]
    public async Task Handler_ShouldReturnOkAndObject_WhenUserExist()
    {
        // Arrange
        ListSalonsQueryHandler _sut;
        _sut = new ListSalonsQueryHandler(salonsRepository);
        ContextGenerator.Add_SalonWithRelated(context);

        //// Act
        var result = await _sut.Handle(new ListSalonsQuery(1, 5), default);

        //// Assert
        ///
        result.Value.Should().ContainEquivalentOf(ContextGenerator.salonWithStaticId);
    }
}