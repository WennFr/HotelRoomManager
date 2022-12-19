using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using HotelRoomManager.Data;
using HotelRoomManager.Messages;

namespace HotelRoomManager.RoomControllers
{
    public class RoomController
    {
        public ApplicationDbContext dbContext { get; set; }
        public RoomController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public string ControlCorrectRoomType()
        {
            Console.WriteLine($"{Environment.NewLine}Rumstyp: [1]Single eller [2]Double?:");

            while (true)
            {
                var input = Console.ReadLine();
                if (Enum.TryParse<Room.RoomType>(input, ignoreCase: true, out var type) && Enum.IsDefined(type))
                    return type.ToString();

                Console.WriteLine("Var god välj mellan Single eller Double. ");
            }
        }
        public int ControlExtraBedsByTypeAndSize(string type, int size)
        {

            if (type == Convert.ToString(Room.RoomType.Single))
                return Convert.ToInt32(Room.ExtraBeds.zero);

            if (size < 30)
                return Convert.ToInt32(Room.ExtraBeds.one);

            return Convert.ToInt32(Room.ExtraBeds.two);

        }

        public Room ChooseRoom()
        {
            int intSelection;
            Console.WriteLine($"Välj Id på rummet du vill ändra på:");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out intSelection) &&
                    dbContext.Rooms.Any(c => c.Id == intSelection))
                {
                    var roomSelection = dbContext.Rooms.FirstOrDefault(s => s.Id == intSelection);
                    Console.Clear();
                    return roomSelection;
                }

                Message.ChooseBetweenAvailableMenuNumbers();
            }

        }

        public void DisplayChosenRoom(Room room)
        {

            Console.WriteLine("{0,-17} {1,-20} {2,-20} {3,-20}", $"{Environment.NewLine}RumsID", "Rumstyp",
                "Storlek", $"Tillåtna extrasängar{Environment.NewLine}");
            Console.WriteLine("{0,-15} {1,-20} {2,-20} {3,-20}",
                $"{room.Id}",
                $"{room.Type}",
                $"{room.Size}",
                $"{room.ExtraBed}{Environment.NewLine}");

        }



    }
}
