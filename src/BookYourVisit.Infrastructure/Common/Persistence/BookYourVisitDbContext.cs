using BookYourVisit.Application.Common.Interfaces;
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
using System.Reflection;

namespace BookYourVisit.Infrastructure.Common.Persistence;
public class BookYourVisitDbContext : DbContext, IUnitOfWork
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
    public BookYourVisitDbContext(DbContextOptions<BookYourVisitDbContext> options) : base(options)
    {
    }
    public async Task CommitChangesAsync()
    {
        await SaveChangesAsync();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer();
    //}
}
