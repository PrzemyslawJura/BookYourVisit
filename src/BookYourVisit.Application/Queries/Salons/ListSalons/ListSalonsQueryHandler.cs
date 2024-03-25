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
        var result = _salonsRepository.ListSalonsAsync(request.page, request.pageSize);

        if (!result.Result.Any())
        {
            return Error.NotFound(description: "Salons not found");
        }

        return await result;
    }
}
