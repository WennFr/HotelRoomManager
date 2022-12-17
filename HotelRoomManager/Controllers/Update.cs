using HotelRoomManager.Data;
using HotelRoomManager.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRoomManager.CustomerControllers;
using HotelRoomManager.Messages;

namespace HotelRoomManager.Controllers
{
    public class Update
    {
        public ApplicationDbContext dbContext { get; set; }
        public Update(ApplicationDbContext context)
        {
            dbContext = context;
        }
       
        public void UpdateRoom()
        {
            Console.Clear();
            Console.WriteLine("Ändra rum");
            Console.WriteLine($"=================== {Environment.NewLine}");
            var roomController = new RoomController(dbContext);
            var read = new Read(dbContext);

            read.ReadAllRooms();
            var room = roomController.ChooseRoom();

            var isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine($"Valt rum: {room.Id}|Våning:{room.Floor}|Rumstyp:{room.Type}|Storlek:{room.Size}kvm|Tillåtna extrasängar:{room.ExtraBed}{Environment.NewLine}");
                Console.WriteLine("Vad vill du ändra?");
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
                        Console.WriteLine($"{Environment.NewLine}Tryck på enter för att gå tillbaka till menyn.");
                        Console.ReadKey();
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


        public void UpdateBooking()
        {
        }
    }
}
