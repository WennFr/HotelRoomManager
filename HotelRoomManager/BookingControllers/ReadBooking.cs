using HotelRoomManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.BookingControllers
{
    public class ReadBooking
    {
        public ApplicationDbContext dbContext { get; set; }
        public ReadBooking(ApplicationDbContext context)
        {
            dbContext = context;
        }



    }
}
