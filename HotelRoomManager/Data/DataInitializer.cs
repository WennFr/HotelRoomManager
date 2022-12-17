using System.Globalization;
using HotelRoomManager.CustomerControllers;
using HotelRoomManager.RoomControllers;
using Microsoft.EntityFrameworkCore;
using static HotelRoomManager.Data.Room;

namespace HotelRoomManager.Data;

public class DataInitializer
{
    public ApplicationDbContext dbContext { get; set; }
    public DataInitializer(ApplicationDbContext context)
    {
        dbContext = context;
    }

    public void Migrate()
    {
        dbContext.Database.Migrate();
    }

    public void Seed()
    {
        SeedSalutations();
        dbContext.SaveChanges();

        SeedCustomers();
        SeedRooms();
        dbContext.SaveChanges();

        SeedBooking();
        dbContext.SaveChanges();
    }

    public void SeedSalutations()
    {
        if (!dbContext.Salutations.Any(s => s.SalutationType == "Mr."))
        {
            dbContext.Salutations.Add(new Salutation()
            {
                SalutationType = "Mr."
            });
        }

        if (!dbContext.Salutations.Any(s => s.SalutationType == "Ms."))
        {
            dbContext.Salutations.Add(new Salutation()
            {
                SalutationType = "Ms."
            });
        }

    }

    public void SeedCustomers()
    {
        var customerController = new CustomerController(dbContext);
        if (!dbContext.Customers.Any(s => s.FirstName == "Lars" && s.LastName == "Johansson"))
        {
           
            dbContext.Customers.Add(new Customer()
            {
                FirstName = "Lars",
                LastName = "Johansson",
                Address = "Torsgatan 7",
                Phone = "+46-222238934",
                Salutation = customerController.GetMaleSalutation()
                
            });

        }

        if (!dbContext.Customers.Any(s => s.FirstName == "Maya" && s.LastName == "Schulz"))
        {
            dbContext.Customers.Add(new Customer()
            {
                FirstName = "Maya",
                LastName = "Schulz",
                Address = "Wrangelstrasse 127",
                Phone = "+49-111555350",
                Salutation = customerController.GetFemaleSalutation()
            });
        }

        if (!dbContext.Customers.Any(s => s.FirstName == "Rowan" && s.LastName == "Wilson"))
        {
            dbContext.Customers.Add(new Customer()
            {
                FirstName = "Rowan",
                LastName = "Wilson",
                Address = "383 Sauchiehall St.",
                Phone = "+44-333623339",
                Salutation = customerController.GetMaleSalutation()
            });

        }

        if (!dbContext.Customers.Any(s => s.FirstName == "Hannah" && s.LastName == "Dahlberg"))
        {
            dbContext.Customers.Add(new Customer()
            {
                FirstName = "Hannah",
                LastName = "Dahlberg",
                Address = "Admiralsgatan 89",
                Phone = "+46-777555359",
                Salutation = customerController.GetFemaleSalutation()
            });

        }
    }
    public void SeedRooms()
    {
        var roomController = new RoomController(dbContext);
        var room = new Room();

        if (!dbContext.Rooms.Any(r => r.Id == 1))
        {
            dbContext.Rooms.Add(new Room
            {
                Floor = "1",
                Type = "Single",
                Size = 20,
                ExtraBed = 0

            });
        }

        if (!dbContext.Rooms.Any(r => r.Id == 2))
        {
            dbContext.Rooms.Add(new Room
            {
                Floor = "2",
                Type = "Double",
                Size = 27,
                ExtraBed = 1

            });
        }

        if (!dbContext.Rooms.Any(r => r.Id == 3))
        {
            dbContext.Rooms.Add(new Room
            {
                Floor = "2",
                Type = "Single",
                Size = 20,
                ExtraBed = 0

            });
        }

        if (!dbContext.Rooms.Any(r => r.Id == 4))
        {
            dbContext.Rooms.Add( new Room
            {
                Floor = "1",
                Type = "Double",
                Size = 35,
                ExtraBed = 2
            });
        }

    }
    public void SeedBooking()
    {
        if (!dbContext.Bookings.Any(b => b.Id == 1))
        {
            var customer = new Customer();
            foreach (var c in dbContext.Customers)
                if (c.Id == 3)
                    customer = c;

            var room = new Room();
            foreach (var r in dbContext.Rooms)
                if (r.Id == 3)
                    room = r;

            dbContext.Bookings.Add(new Booking()
            {
                StartDate = DateTime.ParseExact("2023-03-05", "yyyy-MM-dd", CultureInfo.CurrentCulture),
                EndDate = DateTime.ParseExact("2023-03-10", "yyyy-MM-dd", CultureInfo.CurrentCulture),
                Customer = customer,
                Room = room
            });

        }
    }

}