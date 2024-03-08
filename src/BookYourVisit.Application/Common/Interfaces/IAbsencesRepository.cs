using BookYourVisit.Domain.Absences;

namespace BookYourVisit.Application.Common.Interfaces;
public interface IAbsencesRepository
{
    Task AddAbsenceAsync(Absence absence);
    Task UpdateAsync(Absence absence);
    Task<Absence?> GetByIdAsync(Guid id);
    Task<List<Absence?>> ListByWorkerIdAsync(Guid workerId);
    Task RemoveAbsenceAsync(Absence absence);
    Task RemoveAbsencesAsync(List<Absence> absences);
}
