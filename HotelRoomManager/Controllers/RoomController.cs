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
        private List<Room> allRooms = new List<Room>();

        public List<Room> AllRooms
        {
            get
            {
                return allRooms;
            }
            //set{}
        }
        
    }
}
