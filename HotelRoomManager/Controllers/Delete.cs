using HotelRoomManager.Data;
using HotelRoomManager.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRoomManager.CustomerControllers;
using HotelRoomManager.Messages;

namespace HotelRoomManager.Controllers
{
    public class Delete
    {
        public ApplicationDbContext dbContext { get; set; }
        public Delete(ApplicationDbContext context)
        {
            dbContext = context;
        }

       

        public void DeleteRoom()
        {




        }


        public void DeleteBooking()
        {




        }



    }
}
