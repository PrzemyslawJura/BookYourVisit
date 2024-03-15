using BookYourVisit.Domain.Salons;
using ErrorOr;
using MediatR;

namespace BookYourVisit.Application.Queries.Salons.ListSalons;
public record ListSalonsQuery(int page, int pageSize) : IRequest<ErrorOr<List<Salon?>>>;
