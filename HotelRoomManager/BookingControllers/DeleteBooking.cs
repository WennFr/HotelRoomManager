using HotelRoomManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.BookingControllers
{
    public class DeleteBooking
    {
        public ApplicationDbContext dbContext { get; set; }
        public DeleteBooking(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void Delete()
        {




        }







    }
}
