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
    }
}
