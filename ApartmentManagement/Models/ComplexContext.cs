using Microsoft.EntityFrameworkCore;

namespace ApartmentManagement.Models
{
    public class ComplexContext : DbContext //DbContext is from Entity Framework Core
    {
        public ComplexContext(DbContextOptions<ComplexContext> options) : base(options)
        {

        }
        //table 1
        public DbSet<Complex> Complexes { get; set; }

        //table 2
        public DbSet<Unit> Units { get; set; }

        //data seeding

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Complex>().HasData(
                new Complex()
                {
                    Id = 1,
                    Name = "Great Apartments",
                    ImageName = "Complex1.jpg",
                    Location = "Houston",
                    PhoneNumber = "713-345-6789",
                    Landlord = "Doctor Landlord",
                },
                new Complex()
                {
                    Id = 2,
                    Name = "Village of Apartments",
                    ImageName = "Complex2.jpg",
                    Location = "Tuscon",
                    PhoneNumber = "520-000-0001",
                    Landlord = "Misses Landlord"
                },
                new Complex()
                {
                    Id = 3,
                    Name = "Sketchy and Cheap Apartments",
                    ImageName = "Complex3.jpg",
                    Location = "San Diego",
                    PhoneNumber = "619-000-0123",
                    Landlord = "Mister Landlord"
                });

            modelBuilder.Entity<Unit>().HasData(
                new Unit()
                {
                    Id = 1,
                    ComplexId = 1,
                    UnitNumber = 10,
                    UnitLetter = "A",
                    Beds = 3,
                    Baths = 2,
                    Rent = 1500.00M,
                    IsAvailable = true
                },
                new Unit()
                {
                    Id = 2,
                    ComplexId = 1,
                    UnitNumber = 10,
                    UnitLetter = "B",
                    Beds = 4,
                    Baths = 3,
                    Rent = 1900.00M,
                    IsAvailable = true
                },
                new Unit()
                {
                    Id = 3,
                    ComplexId = 2,
                    UnitNumber = 20,
                    UnitLetter = "A",
                    Beds = 1,
                    Baths = 1,
                    Rent = 1200.00M,
                    IsAvailable = true
                },
                new Unit()
                {
                    Id = 4,
                    ComplexId = 3,
                    UnitNumber = 30,
                    UnitLetter = "A",
                    Beds = 1,
                    Baths = 1,
                    Rent = 3000.00M,
                    IsAvailable = true
                });

        }
    }
}
