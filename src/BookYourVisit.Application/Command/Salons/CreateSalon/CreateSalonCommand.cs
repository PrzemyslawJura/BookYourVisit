using BookYourVisit.Domain.Salons;
using ErrorOr;
using MediatR;

namespace BookYourVisit.Application.Command.Salons.CreateSalon;

public record CreateSalonCommand(string name,
        string description,
        string mainPhoto,
        string photos,
        string phoneNumber,
        string email,
        float latitude,
        float longitute) : IRequest<ErrorOr<Salon>>;

