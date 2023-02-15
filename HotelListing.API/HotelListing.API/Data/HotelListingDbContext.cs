using Microsoft.EntityFrameworkCore;
namespace HotelListing.API.Data
{
    public class HotelListingDbContext:DbContext
    {

        public HotelListingDbContext(DbContextOptions options) : base(options)
        {
            //its taking db context options and its inheritance from the base
            //take base options from program.cs passing it down to the base
            //the code below
            /*

             builder.Services.AddDbContext<HotelListingDbContext>(options =>
                {
                    options.UseSqlServer(connectionString);
                });

             */
        }

        //letting the db context know about the database tables
        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id=1,
                    Name="South Africa",
                    ShortName="SA"
                },
                 new Country
                 {
                     Id = 2,
                     Name = "United States Of America",
                     ShortName = "USA"
                 }
                
             );

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Sandton City Hotel",
                    Address = "Sandton City",
                    Rating = 4.5,
                    CountryId = 1
              
                },
                new Hotel
                {
                    Id = 2,
                    Name = "The Radisson Blu Hotel",
                    Address = "New York",
                    Rating = 5,
                    CountryId = 2
                },
                new Hotel
                {
                    Id = 3,
                    Name = "The Beverly Hotel",
                    Address = "Umhlanga Rocks",
                    Rating = 6,
                    CountryId = 1,

                }

            );


        }


    }
}
