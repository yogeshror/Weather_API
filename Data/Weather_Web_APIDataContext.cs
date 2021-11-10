using Microsoft.EntityFrameworkCore;

namespace Weather_API.Models
{
    //Connects the Model to the database.
    public class Weather_Web_APIDataContext : DbContext
    {
        public Weather_Web_APIDataContext(DbContextOptions<Weather_Web_APIDataContext> options)
            : base(options)
        {
        }

        public DbSet<Weather_API.Model.Weather> Weather { get; set; }
    }
}
