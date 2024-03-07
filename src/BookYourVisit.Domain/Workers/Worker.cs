using BookYourVisit.Domain.Absences;
using BookYourVisit.Domain.Salons;
using BookYourVisit.Domain.Services;
using ErrorOr;
using Throw;

namespace BookYourVisit.Domain.Workers;
public class Worker
{
    public List<Guid> _serviceIds = new();
    public List<Guid> _absenceIds = new();

    public Guid Id { get; private set; }
    public string FirstName { get; private set; } = null!;
    public string SecondName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string PhoneNumber { get; private set; }
    public bool IsDelete { get; private set; } = false;
    public Guid SalonId { get; private set; }

    public IEnumerable<Absence>? Absences { get; private set; }
    public IEnumerable<Service> Services { get; private set; }
    public Salon Salon { get; private set; }

    public Worker(
        string firstName,
        string secondName,
        string email,
        string phoneNumber,
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
    public ErrorOr<Success> AddAbsence(Absence absence)
    {
        _absenceIds.Throw().IfContains(absence.Id);

        _absenceIds.Add(absence.Id);

        return Result.Success;
    }
    public bool HasAbsence(Guid absenceId)
    {
        return _absenceIds.Contains(absenceId);
    }
    public void RemoveAbsence(Guid absenceId)
    {
        _absenceIds.Throw().IfNotContains(absenceId);

        _absenceIds.Remove(absenceId);
    }
    public ErrorOr<Success> AddService(Service service)
    {
        _serviceIds.Throw().IfContains(service.Id);

        _serviceIds.Add(service.Id);

        return Result.Success;
    }
    public bool HasService(Guid serviceId)
    {
        return _serviceIds.Contains(serviceId);
    }
    public void RemoveService(Guid serviceId)
    {
        _serviceIds.Throw().IfNotContains(serviceId);

        _serviceIds.Remove(serviceId);
    }
}
