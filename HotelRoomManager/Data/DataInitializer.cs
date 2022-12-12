using Microsoft.EntityFrameworkCore;

namespace HotelRoomManager.Data;

public class DataInitializer
{
    private static ApplicationDbContext dbContext;

    public void MigrateAndSeed()
    {
        dbContext = Builder.GetDbContext();
        dbContext.Database.Migrate();
        SeedSalutations();
        SeedExtraBeds();
        dbContext.SaveChanges();

        SeedCustomers();
        dbContext.SaveChanges();

    }

    public void SeedSalutations()
    {
        if (!dbContext.Salutation.Any(s => s.SalutationType == "Mr."))
        {
            dbContext.Salutation.Add(new Salutation()
            {
                SalutationType = "Mr."
            });
        }
        if (!dbContext.Salutation.Any(s => s.SalutationType == "Ms."))
        {
            dbContext.Salutation.Add(new Salutation()
            {
                SalutationType = "Ms."
            });
        }

    }

    public void SeedExtraBeds()
    {
        if (!dbContext.ExtraBed.Any(e => e.AllowedAmountOfExtraBeds == 0))
        {
            dbContext.ExtraBed.Add(new ExtraBed()
            {
                AllowedAmountOfExtraBeds = 0
            });
        }

        if (!dbContext.ExtraBed.Any(e => e.AllowedAmountOfExtraBeds == 1))
        {
            dbContext.ExtraBed.Add(new ExtraBed()
            {
                AllowedAmountOfExtraBeds = 1
            });
        }

        if (!dbContext.ExtraBed.Any(e => e.AllowedAmountOfExtraBeds == 2))
        {
            dbContext.ExtraBed.Add(new ExtraBed()
            {
                AllowedAmountOfExtraBeds = 2
            });
        }

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
                Phone = "+46-222238934",
                SalutationId = 1
            });

        }

        if (!dbContext.Customer.Any(s => s.FirstName == "Rowan" && s.LastName == "Wilson"))
        {
            dbContext.Customer.Add(new Customer()
            {
                FirstName = "Rowan",
                LastName = "Wilson",
                Address = "383 Sauchiehall St.",
                Phone = "+44-333623339",
                SalutationId = 1
            });

        }



        if (!dbContext.Customer.Any(s => s.FirstName == "Maya" && s.LastName == "Schulz"))
        {
            dbContext.Customer.Add(new Customer()
            {
                FirstName = "Maya",
                LastName = "Schulz",
                Address = "Wrangelstrasse 127",
                Phone = "+49-111555350",
                SalutationId = 2
            });

        }


        if (!dbContext.Customer.Any(s => s.FirstName == "Hannah" && s.LastName == "Dahlberg"))
        {
            dbContext.Customer.Add(new Customer()
            {
                FirstName = "Hannah",
                LastName = "Dahlberg",
                Address = "Admiralsgatan 89",
                Phone = "+46-777555359",
                SalutationId = 2
            });

        }

    }













}