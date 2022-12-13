using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using HotelRoomManager.Data;

namespace HotelRoomManager.Controllers
{
    public class RoomController
    {
        private Room.RoomType roomType;






        public int ControlExtraBedsBySize(Room room)
        {

            if (room.Type == Convert.ToString(Room.RoomType.Single))
                return Convert.ToInt32(Room.ExtraBeds.zero);

            if (room.Size < 30)
                return Convert.ToInt32(Room.ExtraBeds.one);

            return Convert.ToInt32(Room.ExtraBeds.two);

        }






    }
}
