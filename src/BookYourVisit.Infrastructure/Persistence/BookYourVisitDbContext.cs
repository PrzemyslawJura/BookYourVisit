using BookYourVisit.Domain.Absences;
using BookYourVisit.Domain.Messages;
using BookYourVisit.Domain.Reviews;
using BookYourVisit.Domain.Salons;
using BookYourVisit.Domain.Services;
using BookYourVisit.Domain.Users;
using BookYourVisit.Domain.Visits;
using BookYourVisit.Domain.Workers;
using BookYourVisit.Domain.WorkingSlots;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookYourVisit.Infrastructure.Persistence;
public class BookYourVisitDbContext : DbContext
{
    public DbSet<Absence> Absences { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<Message> Messages { get; set; } = null!;
    public DbSet<Review> Reviews { get; set; } = null!;
    public DbSet<Salon> Salons { get; set; } = null!;
    public DbSet<Service> Services { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Visit> Visits { get; set; } = null!;
    public DbSet<Worker> Workers { get; set; } = null!;
    public DbSet<WorkingSlot> WorkingSlots { get; set; } = null!;
    public BookYourVisitDbContext(DbContextOptions options) : base(options)
    {
    }
}
