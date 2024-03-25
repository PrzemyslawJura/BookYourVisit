using BookYourVisit.Infrastructure.Common.Persistence;
using BookYourVisit.Infrastructure.Repositories;
using BookYourVisit.Tests.Unit.Common;
using FluentAssertions;

namespace BookYourVisit.Tests.Unit;

public class SalonsRepositoryTests
{
    private readonly SalonsRepository _sut;
    private readonly BookYourVisitDbContext context;

    public SalonsRepositoryTests()
    {
        context = ContextGenerator.Generate();
        _sut = new SalonsRepository(context);
    }

    [Fact]
    public async Task ListSalonAsync_ShouldReturnEmptyList_WhenNoSalonsExist()
    {
        // Arrange

        //// Act
        var salons = await _sut.ListSalonsAsync(1, 5);

        //// Assert
        salons.Should().BeEmpty();

    }

    [Fact]
    public async Task ListSalonAsync_ShouldReturnObject_WhenUserExist()
    {
        // Arrange
        ContextGenerator.Add_SalonWithRelated(context);

        //// Act
        var result = await _sut.ListSalonsAsync(1, 5);

        //// Assert
        AssertionOptions.AssertEquivalencyUsing(options => options);
        result.Should().Contain(ContextGenerator.salonWithStaticId);
    }
}
