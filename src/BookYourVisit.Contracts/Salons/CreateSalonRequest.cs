namespace BookYourVisit.Contracts.Salons;
public record CreateSalonRequest(string name,
        string description,
        string mainPhoto,
        string photos,
        string phoneNumber,
        string email,
        float latitude,
        float longitute);

