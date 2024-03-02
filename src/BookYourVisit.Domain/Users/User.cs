namespace BookYourVisit.Domain.Users;
public class User
{
    public List<Guid> _reviewIds = new();
    public List<Guid> _visitIds = new();

    public Guid Id { get; private set; }
    public string FirstName { get; private set; } = null!;
    public string SecondName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public int PhoneNumber { get; private set; }
    public bool IsDelete { get; private set; } = false;

    public User(
        string firstName,
        string secondName,
        string email,
        int phoneNumber,
        Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        FirstName = firstName;
        SecondName = secondName;
        Email = email;
        PhoneNumber = phoneNumber;
    }
    private User()
    {
    }
}
