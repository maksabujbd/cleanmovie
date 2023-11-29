using CleanMovie.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanMovie.Infrastructure;

public class MovieDbContext : DbContext
{
    public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // One to many (Member and Rentals
        modelBuilder.Entity<Member>()
            .HasOne<Rental>(s => s.Rental)
            .WithMany(r => r.Members)
            .HasForeignKey(s => s.RentalId);

        //Many to many (rental and movie)
        modelBuilder.Entity<MovieRental>()
            .HasKey(g => new { g.RentalId, g.MovieId });

        // Handle decimals to avoid precision loss
        modelBuilder.Entity<Rental>()
            .Property(p => p.TotalCost)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Movie>()
            .Property(p => p.RentalCost)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Tokens>()
            .HasNoKey();
        modelBuilder.Entity<Users>()
            .HasKey(x => x.UserId);

        // base.OnModelCreating(modelBuilder);
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<MovieRental> MovieRentals { get; set; }
    public DbSet<Users> Users { get; set; }
    public DbSet<Tokens> Tokens { get; set; }
}