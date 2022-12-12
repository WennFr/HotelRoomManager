using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.Data
{
    public class Room
    {
        public int Id { get; set; }

        public string Floor { get; set; }

        public string Type { get; set; }

        public int Size { get; set; }

    }
    

}
