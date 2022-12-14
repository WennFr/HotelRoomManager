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
        public string ControlCorrectRoomType()
        {
            Console.WriteLine($"{Environment.NewLine}Rumstyp: Single eller Double?:");

            while (true)
            {
                if (Enum.TryParse<Room.RoomType>(Console.ReadLine(), ignoreCase: true, out var type))
                    return type.ToString();

                Console.WriteLine("Var god välj mellan single eller double. ");
            }
        }
        public int ControlExtraBedsBySize(string type, int size)
        {

            if (type == Convert.ToString(Room.RoomType.Single))
                return Convert.ToInt32(Room.ExtraBeds.zero);

            if (size < 30)
                return Convert.ToInt32(Room.ExtraBeds.one);

            return Convert.ToInt32(Room.ExtraBeds.two);

        }

    }
}
