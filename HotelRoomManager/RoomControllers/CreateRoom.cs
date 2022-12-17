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
                try
                {
                    Console.WriteLine($"{Environment.NewLine}Rumsvåning:");
                    var floor = Console.ReadLine();
                    var type = roomController.ControlCorrectRoomType();
                    Console.WriteLine($"{Environment.NewLine}Rumsstorlek (siffra i kvm):  ");
                    var size = Convert.ToInt32(Console.ReadLine());
                    var extraBed = roomController.ControlExtraBedsByTypeAndSize(type, size);
                    Console.WriteLine($"{Environment.NewLine}Antal tillåtna sängar sätts automatiskt efter rumsstorlek.");
                    Thread.Sleep(2000);
                    dbContext.Rooms.Add(new Room()
                    {
                        Floor = floor,
                        Type = type,
                        Size = size,
                        ExtraBed = extraBed
                    });
                    dbContext.SaveChanges();
                    break;
                }
                catch (Exception ex)
                {
                    Message.WrongInput();
                    continue;
                }
            }
            Console.WriteLine($"{Environment.NewLine}Nytt rum registrerat.");
            Message.PressEnterToReturnToMenu();
        }




    }
}
