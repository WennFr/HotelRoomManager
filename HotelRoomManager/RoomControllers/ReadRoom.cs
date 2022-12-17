using HotelRoomManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.RoomControllers
{
    public class ReadRoom
    {
        public ApplicationDbContext dbContext { get; set; }
        public ReadRoom(ApplicationDbContext context)
        {
            dbContext = context;
        }



        public void ReadAllRooms()
        {
            Console.WriteLine($"{Environment.NewLine}ID|Floor|Type|Size|Tillåtna extrasängar {Environment.NewLine}");
            foreach (var room in dbContext.Rooms)
            {
                Console.WriteLine($"{room.Id} |{room.Floor} |{room.Type}/{room.Size}/{room.ExtraBed}");
                Console.WriteLine($"--|--|----------------------------------------------------");
            }
        }





    }
}
