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

        return createSalonResult.Match(
        salon => CreatedAtAction(
        nameof(GetSalonById),
        new
        {
            name = salon.Name,
            description = salon.Description,
            mainPhoto = salon.MainPhoto,
            photos = salon.Photos,
            phoneNumber = salon.PhoneNumber,
            email = salon.Email,
            latitude = salon.Latitude,
            longitute = salon.Longitude
        },
        new CreateSalonResponse(name: salon.Name,
            description: salon.Description,
            mainPhoto: salon.MainPhoto,
            photos: salon.Photos,
            phoneNumber: salon.PhoneNumber,
            email: salon.Email,
            latitude: salon.Latitude,
            longitute: salon.Longitude)),
       errors => Problem());
    }

    [HttpGet("{salonId:guid}")]
    public async Task<IActionResult> GetSalonById(Guid salonId)
    {
        var command = new GetSalonByIdQuery(salonId);

        var getSalonByIdResult = await _mediator.Send(command);


        return getSalonByIdResult.Match(
        salon => Ok(new CreateSalonResponse(
            name: salon.Name,
            description: salon.Description,
            mainPhoto: salon.MainPhoto,
            photos: salon.Photos,
            phoneNumber: salon.PhoneNumber,
            email: salon.Email,
            latitude: salon.Latitude,
            longitute: salon.Longitude)),
        errors => Problem());
    }

    [HttpGet]
    public async Task<IActionResult> ListSalons(int page, int pageSize)
    {
        var command = new ListSalonsQuery(page, pageSize);

        var listSalonsResult = await _mediator.Send(command);

        return listSalonsResult.Match(
            salons => Ok(salons.ConvertAll(salon => new CreateSalonResponse(
            name: salon.Name,
            description: salon.Description,
            mainPhoto: salon.MainPhoto,
            photos: salon.Photos,
            phoneNumber: salon.PhoneNumber,
            email: salon.Email,
            latitude: salon.Latitude,
            longitute: salon.Longitude))),
        errors => Problem());
    }

    //[HttpDelete("{salonId:guid}")]
    //public async Task<IActionResult> DeleteSalon(Guid salonId)
    //{

    //}
}
