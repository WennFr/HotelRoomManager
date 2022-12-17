using HotelRoomManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.RoomControllers
{
    public class DeleteRoom
    {
        public ApplicationDbContext dbContext { get; set; }
        public DeleteRoom(ApplicationDbContext context)
        {
            dbContext = context;
        }


        public void Delete()
        {




        }





    }
}
