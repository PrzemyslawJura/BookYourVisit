namespace BookYourVisit.Contracts.Salons;
public record CreateSalonResponse(string name,
        string description,
        string mainPhoto,
        string photos,
        string phoneNumber,
        string email,
        float latitude,
        float longitute);