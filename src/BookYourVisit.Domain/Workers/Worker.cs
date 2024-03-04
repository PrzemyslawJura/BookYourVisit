using BookYourVisit.Domain.Absences;
using BookYourVisit.Domain.Salons;
using BookYourVisit.Domain.Services;

namespace BookYourVisit.Domain.Workers;
public class Worker
{
    public List<Guid> _serviceIds = new();
    public List<Guid> _absenceIds = new();

    public Guid Id { get; private set; }
    public string FirstName { get; private set; } = null!;
    public string SecondName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public int PhoneNumber { get; private set; }
    public bool IsDelete { get; private set; } = false;
    public Guid SalonId { get; private set; }

    public IEnumerable<Absence>? Absences { get; private set; }
    public IEnumerable<Service> Services { get; private set; }
    public Salon Salon { get; private set; }

    public Worker(
        string firstName,
        string secondName,
        string email,
        int phoneNumber,
        Guid salonId,
        Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        FirstName = firstName;
        SecondName = secondName;
        Email = email;
        PhoneNumber = phoneNumber;
        SalonId = salonId;
    }
    private Worker()
    {
    }
}
