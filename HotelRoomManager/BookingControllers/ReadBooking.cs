using HotelRoomManager.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRoomManager.Messages;
using Microsoft.EntityFrameworkCore.Query;

namespace HotelRoomManager.BookingControllers
{
    public class ReadBooking
    {
        public ApplicationDbContext dbContext { get; set; }
        public ReadBooking(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public bool ReadAllBookings()
        {
            Console.WriteLine($"{Environment.NewLine}BokningsID\tFrån\t\tTill\t\tKund\t\tRum {Environment.NewLine}");
            foreach (var booking in dbContext.Bookings
                         .Include(b => b.Customer)
                         .ThenInclude(c=> c.Salutation)
                         .Include(b => b.Room))
            {
                Console.WriteLine($"{booking.Id}\t\t{booking.StartDate.ToShortDateString()}\t{booking.EndDate.ToShortDateString()} " +
                                  $"\t{booking.Customer.Salutation.SalutationType}{booking.Customer.LastName}\t{booking.Room.Id}");
                Console.WriteLine($"------------------------------------------------------------------------------");
            }

            if (dbContext.Bookings.Count() > 0)
                return true;

            return false;


        }




    }
}
