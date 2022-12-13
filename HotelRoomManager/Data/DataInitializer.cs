using HotelRoomManager.Controllers;
using Microsoft.EntityFrameworkCore;

namespace HotelRoomManager.Data;

public class DataInitializer
{
    private static ApplicationDbContext dbContext;


    public void Migrate()
    {
        dbContext = Builder.GetDbContext();
        dbContext.Database.Migrate();

    }
    public void Seed()
    {
        SeedSalutations();
        SeedExtraBeds();
        dbContext.SaveChanges();

        SeedCustomers();
        // SeedRooms();
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

    public void SeedRooms()
    {
        var roomController = new RoomController();
        var room = new Room();

        if (!dbContext.Room.Any(r => r.Id == 1))
        {
            dbContext.Room.Add(new Room()
            {
                Floor = "1",
                Type = "Single",
                Size = 20,
                ExtraBedId = 1
            });

        }

        if (!dbContext.Room.Any(r => r.Id == 2))
        {
            dbContext.Room.Add(new Room()
            {
                Floor = "2",
                Type = "Double",
                Size = 27,
                ExtraBedId = 2
            });

        }

        if (!dbContext.Room.Any(r => r.Id == 3))
        {

            dbContext.Room.Add(new Room()
            {
                Floor = "2",
                Type = "Single",
                Size = 20,
                ExtraBedId = 1
            });

        }

        if (!dbContext.Room.Any(r => r.Id == 4))
        {

             roomController = new RoomController();
             room = new Room()
            {
                Floor = "1",
                Type = "Double",
                Size = 35,
            };

            room.ExtraBedId = roomController.ControlExtraBedsBySize(room);

            dbContext.Room.Add(room);


        }




    }













}