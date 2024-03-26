using BookYourVisit.Application.Command.Salons.CreateSalon;
using BookYourVisit.Application.Queries.Salons.GetSalonById;
using BookYourVisit.Application.Queries.Salons.ListSalons;
using BookYourVisit.Contracts.Salons;
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

    //ApiControler

    [HttpPost]
    public async Task<IActionResult> CreateSalon(CreateSalonRequest request)
    {
        var command = new CreateSalonCommand(request.name,
        request.description,
        request.mainPhoto,
        request.photos,
        request.phoneNumber,
        request.email,
        request.latitude,
        request.longitute);

        var createSalonResult = await _mediator.Send(command);

        if (createSalonResult.IsError == true)
        {
            return NotFound();
        }

        return Ok(createSalonResult);
    }

    [HttpGet("{salonId:guid}")]
    public async Task<IActionResult> GetSalonById(Guid salonId)
    {
        var command = new GetSalonByIdQuery(salonId);

        var getSalonByIdResult = await _mediator.Send(command);

        if (getSalonByIdResult.IsError == true)
        {
            return NotFound();
        }

        return Ok(getSalonByIdResult);
    }

    [HttpGet]
    public async Task<IActionResult> ListSalons(int page, int pageSize)
    {
        var command = new ListSalonsQuery(page, pageSize);

        var listSalonsResult = await _mediator.Send(command);

        if (listSalonsResult.IsError == true)
        {
            return NotFound();
        }

        return Ok(listSalonsResult);
    }

    //[HttpDelete("{salonId:guid}")]
    //public async Task<IActionResult> DeleteSalon(Guid salonId)
    //{

    //}
}
