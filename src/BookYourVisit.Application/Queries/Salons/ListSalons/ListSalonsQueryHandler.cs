using BookYourVisit.Application.Common.Interfaces;
using BookYourVisit.Domain.Salons;
using ErrorOr;
using MediatR;

namespace BookYourVisit.Application.Queries.Salons.ListSalons;
public class ListSalonsQueryHandler : IRequestHandler<ListSalonsQuery, ErrorOr<List<Salon?>>>
{
    private readonly ISalonsRepository _salonsRepository;

    public ListSalonsQueryHandler(ISalonsRepository salonsRepository)
    {
        _salonsRepository = salonsRepository;
    }

    public async Task<ErrorOr<List<Salon?>>> Handle(ListSalonsQuery request, CancellationToken cancellationToken)
    {
        if (await _salonsRepository.Count() == 0)
        {
            return Error.NotFound(description: "Salons not found");
        }

        return await _salonsRepository.ListSalonsAsync(request.skip, request.take);
    }
}
