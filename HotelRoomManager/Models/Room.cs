using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.Models
{
    public class Room
    {
        public string RoomName { get; set; }

        public string Floor { get; set; }

        public RoomType RoomType { get; set; }



    }
    public enum RoomType
    {
        Single,
        Double

    }

}
