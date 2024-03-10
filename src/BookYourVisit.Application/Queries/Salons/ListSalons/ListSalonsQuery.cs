using BookYourVisit.Domain.Salons;
using ErrorOr;
using MediatR;

namespace BookYourVisit.Application.Queries.Salons.ListSalons;
public record ListSalonsQuery(int skip, int take) : IRequest<ErrorOr<List<Salon?>>>;
