using BookYourVisit.Application.Common.Interfaces;
using BookYourVisit.Domain.Salons;
using ErrorOr;
using MediatR;

namespace BookYourVisit.Application.Queries.Salons.GetSalonById;
public class GetSalonByIdQueryHandler : IRequestHandler<GetSalonByIdQuery, ErrorOr<Salon?>>
{
    private readonly ISalonsRepository _salonsRepository;

    public GetSalonByIdQueryHandler(ISalonsRepository salonsRepository)
    {
        _salonsRepository = salonsRepository;
    }

    public async Task<ErrorOr<Salon?>> Handle(GetSalonByIdQuery request, CancellationToken cancellationToken)
    {
        var result = _salonsRepository.GetByIdAsync(request.salonId);

        if (result.Result == null)
        {
            return Error.NotFound(description: "Salon not found");
        }

        return await result;
    }
}
