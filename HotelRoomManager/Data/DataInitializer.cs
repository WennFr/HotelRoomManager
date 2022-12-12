using Microsoft.EntityFrameworkCore;

namespace HotelRoomManager.Data;

public class DataInitializer
{
    private static ApplicationDbContext dbContext;

    public void MigrateAndSeed()
    { 
        dbContext = Builder.GetDbContext();
        dbContext.Database.Migrate();
       //SeedCustomers();
        dbContext.SaveChanges();

    }
    public void SeedCustomers()
    {
        if (!dbContext.Customer.Any(s => s.FirstName == "Lars" && s.LastName == "Johansson"))
        {
            dbContext.Customer.Add(new Customer()
            {
                FirstName = "Lars",
                LastName = "Johansson",
                Address = "Torsgatan 7",
                Phone = "+46-222238974",
                
            });

        }














    }