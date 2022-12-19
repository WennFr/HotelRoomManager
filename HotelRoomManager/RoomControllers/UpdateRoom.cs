using HotelRoomManager.Data;
using HotelRoomManager.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRoomManager.Messages;

namespace HotelRoomManager.RoomControllers
{
    public class UpdateRoom
    {
        public ApplicationDbContext dbContext { get; set; }
        public UpdateRoom(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void Update()
        {
            Console.Clear();
            Console.WriteLine("Ändra rum");
            Console.WriteLine($"========= {Environment.NewLine}");
            var roomController = new RoomController(dbContext);
            var readRoom = new ReadRoom(dbContext);

            readRoom.ReadAllRooms();
            var room = roomController.ChooseRoom();

            var isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("{0,-17} {1,-20} {2,-20} {3,-20}", $"{Environment.NewLine}RumsID", "Rumstyp", "Storlek", $"Tillåtna extrasängar{Environment.NewLine}");
                Console.WriteLine("{0,-15} {1,-20} {2,-20} {3,-20}",
                    $"{room.Id}",
                    $"{room.Type}",
                    $"{room.Size}",
                    $"{room.ExtraBed}{Environment.NewLine}");

                Console.WriteLine($"Vad vill du ändra?{Environment.NewLine}");
                Menu.UpdateRoomSelectionMenu();

                var selectionMenuLimit = 3;
                var selection = MenuSelection.ValidateSelection(selectionMenuLimit);

                switch (selection)
                {
                    case 1:
                        Console.WriteLine("Våning:");
                        room.Floor = Console.ReadLine();
                        break;
                    case 2:
                        room.Type = roomController.ControlCorrectRoomType();
                        Console.WriteLine("Storlek:");
                        room.Size = validIntSelection();
                        room.ExtraBed = roomController.ControlExtraBedsByTypeAndSize(room.Type, room.Size);
                        break;
                    case 0:
                        dbContext.SaveChanges();
                        Console.WriteLine("Nytt rum sparat.");
                        Message.PressEnterToReturnToMenu();
                        isRunning = false;
                        break;
                }
            }


        }

        public int validIntSelection()
        {
            int intSelection;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out intSelection))
                {
                    return intSelection;
                }
                Console.WriteLine("Du måste skriva in en siffra");
            }
        }







    }
}
