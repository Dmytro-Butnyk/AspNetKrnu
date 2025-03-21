using Domain.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Data;

/// <summary>
/// DbContext for the SportsBookingSystem database
/// </summary>
public class SportsBookDbContext : DbContext
{
    public SportsBookDbContext(DbContextOptions<SportsBookDbContext> options)
        : base(options) { }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<SportField> SportFields { get; set; }
    public virtual DbSet<Booking> Bookings { get; set; }
    public virtual DbSet<Feedback> Feedbacks { get; set; }
    public virtual DbSet<SportFieldType> SportFieldTypes { get; set; }
}