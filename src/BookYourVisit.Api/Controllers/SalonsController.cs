using BookYourVisit.Application.Queries.Salons.ListSalons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookYourVisit.Api.Controllers;

[Route("[controller]")]
public class SalonsController : Controller
{
    private readonly ISender _mediator;

    public SalonsController(ISender mediator)
    {
        _mediator = mediator;
    }

    //[HttpPost]
    //public async Task<IActionResult> CreateSalon(CreateSalonRequest request)
    //{

    //}

    //[HttpGet("{salonId:guid}")]
    //public async Task<IActionResult> GetSalon(Guid salonId)
    //{

    //}

    [HttpGet]
    public async Task<IActionResult> ListSalons(int page, int pageSize)
    {
        var command = new ListSalonsQuery(page, pageSize);

        var listSalonsResult = await _mediator.Send(command);

        return Ok(listSalonsResult);
    }

    //[HttpDelete("{salonId:guid}")]
    //public async Task<IActionResult> DeleteSalon(Guid salonId)
    //{

    //}
}
