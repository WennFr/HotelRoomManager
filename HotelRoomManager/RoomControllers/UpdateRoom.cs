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

            var readRoom = new ReadRoom(dbContext);
            var isAnyRegisteredRooms = readRoom.ReadAllRooms();

            if (!isAnyRegisteredRooms)
            {
                Message.NoRegisteredRooms();
                Message.PressEnterToReturnToMenu();

            }

            else
            {
                var roomController = new RoomController(dbContext);
                var room = roomController.ChooseRoom();
                var isRunning = true;
                while (isRunning)
                {
                    Console.Clear();

                    roomController.DisplayChosenRoom(room);
                    Console.WriteLine($"Vad vill du ändra?{Environment.NewLine}");
                    Menu.UpdateRoomSelectionMenu();

                    var selectionMenuLimit = 3;
                    var selection = MenuSelection.ValidateSelection(selectionMenuLimit);

                    switch (selection)
                    {
                        case 1:
                            Console.WriteLine("Rumsvåning (siffra):");
                            room.Floor = validIntSelection();
                            break;
                        case 2:
                            var newRoomType = roomController.ControlCorrectRoomType();
                            var isCorrectRoomSize = roomController.ControlCorrectRoomSize(room.Size);

                            if (!isCorrectRoomSize)
                                Message.PressEnter();
                            
                            else
                            {
                                room.Type = newRoomType;
                                room.ExtraBed = roomController.ControlExtraBedsByTypeAndSize(room.Type, room.Size);
                            }

                            break;
                        case 3:
                            Console.WriteLine($"Rumsstorlek (siffra i kvm):  ");
                            var newRoomSize = validIntSelection();

                            isCorrectRoomSize = roomController.ControlCorrectRoomSize(newRoomSize);

                            if (!isCorrectRoomSize)
                                Message.PressEnter();
                            

                            else
                            {
                                room.Size = newRoomSize;
                                room.ExtraBed = roomController.ControlExtraBedsByTypeAndSize(room.Type, room.Size);
                            }
                            break;

                        case 0: 
                            Console.Clear();
                            dbContext.SaveChanges();
                            Message.ChangesSaved();
                            Message.PressEnterToReturnToMenu();
                            isRunning = false;
                            break;
                    }
                }

            }


        }

        public int validIntSelection()
        {
            int intSelection;
            while (true)
            {
                Console.Write(">");
                if (int.TryParse(Console.ReadLine(), out intSelection))
                {
                    return intSelection;
                }
                Console.WriteLine("Du måste skriva in en siffra");
            }
        }

    }
}
