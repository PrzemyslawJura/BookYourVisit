using BookYourVisit.Domain.Salons;
using ErrorOr;
using MediatR;

namespace BookYourVisit.Application.Queries.Salons.GetSalonById;

public record GetSalonByIdQuery(Guid salonId) : IRequest<ErrorOr<Salon?>>;
