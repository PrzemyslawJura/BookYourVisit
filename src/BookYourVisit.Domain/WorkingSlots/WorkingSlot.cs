namespace BookYourVisit.Domain.WorkingSlots;
public class WorkingSlot
{
    public Guid Id { get; private set; }
    public DayOfWeek DayOfWeek { get; private set; }
    public float HourFrom { get; private set; }
    public float HourTo { get; private set; }
    public bool IsDelete { get; private set; } = false;
    public Guid SalonId { get; private set; }

    public WorkingSlot(
        DayOfWeek dayOfWeek,
        float hourFrom,
        float hourTo,
        Guid salonId,
        Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        DayOfWeek = dayOfWeek;
        HourFrom = hourFrom;
        HourTo = hourTo;
        SalonId = salonId;
    }
    private WorkingSlot()
    {
    }
}
