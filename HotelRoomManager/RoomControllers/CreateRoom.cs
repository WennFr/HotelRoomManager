using HotelRoomManager.Data;
using HotelRoomManager.Messages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.RoomControllers
{
    public class CreateRoom
    {
        public ApplicationDbContext dbContext { get; set; }
        public CreateRoom(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public void Create()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Registrera nytt rum");
                Console.WriteLine("===================");
                var roomController = new RoomController(dbContext);
                var isCorrectRoomSize = false;
                try
                {
                    Console.WriteLine($"{Environment.NewLine}Rumsvåning:");
                    Console.Write(">");
                    var newRoomFloor = Console.ReadLine();
                    var newRoomType = roomController.ControlCorrectRoomType();

                    var newRoomSize = 0;
                    while (!isCorrectRoomSize)
                    {
                        Console.WriteLine($"{Environment.NewLine}Rumsstorlek (siffra i kvm):  ");
                        Console.Write(">");
                        newRoomSize = Convert.ToInt32(Console.ReadLine());
                        isCorrectRoomSize = roomController.ControlCorrectRoomSize(newRoomType, newRoomSize);
                    }

                    var newRoomExtraBed = roomController.ControlExtraBedsByTypeAndSize(newRoomType, newRoomSize);
                    Console.WriteLine($"{Environment.NewLine}Antal tillåtna extrasängar sätts automatiskt efter typ och rumsstorlek.");
                    Console.WriteLine($"Tillåtna extrasängar för det nya rummet är: {newRoomExtraBed}.{Environment.NewLine}");
                    Message.PressEnter();
                    dbContext.Rooms.Add(new Room()
                    {
                        Floor = newRoomFloor,
                        Type = newRoomType,
                        Size = newRoomSize,
                        ExtraBed = newRoomExtraBed
                    });
                    dbContext.SaveChanges();
                    break;
                }
                catch (Exception ex)
                {
                    Message.WrongInput();
                    Message.PressEnter();
                    continue;
                }
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Nytt rum registrerat!");
            Console.ForegroundColor = ConsoleColor.Gray;
            Message.PressEnterToReturnToMenu();
        }




    }
}
