using HotelRoomManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.BookingControllers
{
    public class UpdateBooking
    {
        public ApplicationDbContext dbContext { get; set; }
        public UpdateBooking(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void Update()
        {




        }


    }
}
