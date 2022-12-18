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
            
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20}{4,-20}", $"{Environment.NewLine}BokningsID", "Från", "Till", "Namn",$"Rum {Environment.NewLine}");
            foreach (var booking in dbContext.Bookings
                         .Include(b => b.Customer)
                         .ThenInclude(c => c.Salutation)
                         .Include(b => b.Room))
            {
                Console.WriteLine("{0,-18} {1,-20} {2,-20} {3,-19} {4,-20}", 
                    $"{booking.Id}", $"{booking.StartDate.ToShortDateString()}",
                    $"{booking.EndDate.ToShortDateString()}", 
                    $"{booking.Customer.Salutation.SalutationType}{booking.Customer.LastName}", 
                    $"{booking.Room.Id}");
                Console.WriteLine($"-----------------------------------------------------------------------------------------------------------");
            }

            if (dbContext.Bookings.Count() > 0)
                return true;

            return false;


        }




    }
}
