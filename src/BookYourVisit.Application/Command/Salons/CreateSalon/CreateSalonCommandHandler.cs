using BookYourVisit.Application.Common.Interfaces;
using BookYourVisit.Domain.Salons;
using ErrorOr;
using MediatR;

namespace BookYourVisit.Application.Command.Salons.CreateSalon;
public class CreateSalonCommandHandler : IRequestHandler<CreateSalonCommand, ErrorOr<Salon>>
{
    private readonly ISalonsRepository _salonsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSalonCommandHandler(
        ISalonsRepository salonsRepository,
        IUnitOfWork unitOfWork)
    {
        _salonsRepository = salonsRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Salon>> Handle(CreateSalonCommand command, CancellationToken cancellationToken)
    {
        Guid salonId = new Guid();

        var salon = new Salon(
            name: command.name,
            description: command.description,
            mainPhoto: command.mainPhoto,
            photos: command.photos,
            phoneNumber: command.phoneNumber,
            email: command.email,
            latitude: command.latitude,
            longitute: command.longitute);

        await _salonsRepository.AddSalonAsync(salon);
        await _unitOfWork.CommitChangesAsync();

        return salon;
    }
}
