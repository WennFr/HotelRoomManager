using HotelRoomManager.CustomerControllers;
using HotelRoomManager.Data;
using HotelRoomManager.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.RoomControllers
{
    public class DeleteRoom
    {
        public ApplicationDbContext dbContext { get; set; }
        public DeleteRoom(ApplicationDbContext context)
        {
            dbContext = context;
        }


        public void Delete()
        {

            Console.Clear();
            Console.WriteLine("Radera Rum");
            Console.WriteLine("===========");

            var readRoom = new ReadRoom(dbContext);
            var roomController = new RoomController(dbContext);

            var isAnyRegisteredRooms = readRoom.ReadAllRooms();

            if (!isAnyRegisteredRooms)
            {
                Message.NoRegisteredCustomers();
                Message.PressEnterToReturnToMenu();
            }

            else
            {
                var roomToDelete = roomController.ChooseRoom();
                var isRoomBooked = roomController.CheckIfRoomIsBooked(roomToDelete);

                if (isRoomBooked)
                {
                    Message.RoomIsBooked();
                    Message.PressEnterToReturnToMenu();
                }

                else
                {
                    roomController.DisplayChosenRoom(roomToDelete);

                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Är du säker på att du vill ta bort det här rummet? y/n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(">");
                        var selection = Console.ReadLine();

                        if (selection.ToLower() == "n" || selection.ToLower() == "no")
                            break;

                        else if (selection.ToLower() == "y" || selection.ToLower() == "yes")
                        {
                            dbContext.Rooms.Remove(roomToDelete);
                            dbContext.SaveChanges();
                            Console.WriteLine($"Rum raderat.{Environment.NewLine}");
                            Message.PressEnterToReturnToMenu();
                            break;
                        }
                    }


                }

            }

        }

    }
}
