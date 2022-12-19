using HotelRoomManager.Data;
using Microsoft.EntityFrameworkCore;
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
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20}{4,-20}", $"{Environment.NewLine}RumsID", "Rumstyp", "Våning", "Storlek", $"Tillåtna extrasängar {Environment.NewLine}");
            foreach (var room in dbContext.Rooms)
            {
                Console.WriteLine("{0,-18} {1,-20} {2,-20} {3,-19} {4,-20}",
                    $"{room.Id}", 
                    $"{room.Type}",
                    $"{room.Floor}",
                    $"{room.Size}kvm",
                    $"{room.ExtraBed}");
                Console.WriteLine($"-----------------------------------------------------------------------------------------------------------");
            }


        }





    }
}
