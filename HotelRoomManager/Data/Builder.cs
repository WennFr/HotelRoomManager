using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.Data
{
    public class Builder
    {
        public static DbContextOptionsBuilder<ApplicationDbContext> options;
        public static ApplicationDbContext dbContext;


        public static void BuildDatabase()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();

            options = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = config.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        }

        public static void InitializeData()
        {
            using (dbContext = new ApplicationDbContext(options.Options))
            {
                var dataInitializer = new DataInitializer(dbContext);
                dataInitializer.Migrate();
                dataInitializer.Seed();

                //  dbContext.Database.Migrate();
            }

        }

        public static DbContextOptionsBuilder<ApplicationDbContext> GetOptions()
        {
            return options;
        }

        public static ApplicationDbContext GetDbContext()
        {
            return dbContext;
        }







    }
}
