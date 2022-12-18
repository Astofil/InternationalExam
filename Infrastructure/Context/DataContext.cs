using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options): base(options)
    {

    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
        
    // }

    public DbSet<Participant> Participants { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Challenge> Challenges { get; set; }
}

