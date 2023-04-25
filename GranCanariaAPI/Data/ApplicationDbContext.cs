using GranCanariaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GranCanariaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Apartment> Apartments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartment>().HasData(
                new Apartment
                {
                    ApartmentId = 1,
                    Name = "Royal Bungalow",
                    Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                    ImageUrl = "",
                    Occupancy = 4,
                    Rate = 200,
                    Kvm = 55,
                    Comfort = "",
                    CreatedDate = DateTime.Now
                },
              new Apartment
              {
                  ApartmentId = 2,
                  Name = "Premium Pool Bungalow",
                  Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                  ImageUrl = "",
                  Occupancy = 4,
                  Rate = 300,
                  Kvm = 55,
                  Comfort="",
                  CreatedDate = DateTime.Now
              },
              new Apartment
              {
                  ApartmentId = 3,
                  Name = "Luxury Pool Bungalow",
                  Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                  ImageUrl = "",
                  Occupancy = 4,
                  Rate = 400,
                  Kvm = 75,
                  Comfort = "",
                  CreatedDate = DateTime.Now
              },
              new Apartment
              {
                  ApartmentId = 4,
                  Name = "Diamond Bungalow",
                  Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                  ImageUrl = "h",
                  Occupancy = 4,
                  Rate = 550,
                  Kvm = 90,
                  Comfort = "",
                  CreatedDate = DateTime.Now
              },
              new Apartment
              {
                  ApartmentId = 5,
                  Name = "Diamond Pool Bungalow",
                  Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                  ImageUrl = "",
                  Occupancy = 4,
                  Rate = 600,
                  Kvm = 110,
                  Comfort = "",
                  CreatedDate = DateTime.Now
              });
        }
    }
}
