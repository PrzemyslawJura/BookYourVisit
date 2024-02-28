using BookYourVisit.Domain.Addresses;
using BookYourVisit.Domain.Reviews;
using BookYourVisit.Domain.Services;
using BookYourVisit.Domain.Workers;
using BookYourVisit.Domain.WorkingSlots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace BookYourVisit.Domain.Salons;
public class Salon
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public string MainPhoto { get; private set; } = null!;
    public string Photos { get; private set; } = null!;
    public int PhoneNumber { get; private set; }
    public string Email { get; private set; } = null!;
    public float Latitude { get; private set; }
    public float Longitude { get; private set; }
    public bool IsDelete { get; private set; } = false;

    public Address Address { get; private set; } = null!;
    public IEnumerable<Review> Reviews { get; private set; } = Enumerable.Empty<Review>();
    public IEnumerable<Service> Services { get; private set; } = Enumerable.Empty<Service>();
    public IEnumerable<Worker> Workers { get; private set; } = Enumerable.Empty<Worker>();
    public IEnumerable<WorkingSlot> WorkingSlots { get; private set; } = Enumerable.Empty<WorkingSlot>();

    public Salon(
        string name,
        string description,
        string mainPhoto,
        string photos,
        int phoneNumber,
        string email,
        float latitude,
    float longitute,
        Address address,
        Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        Name = name;
        Description = description;
        MainPhoto = mainPhoto;
        Photos = photos;
        PhoneNumber = phoneNumber;
        Email = email;
        Latitude = latitude;
        Longitude = longitute;
        Address = address;
    }

}
