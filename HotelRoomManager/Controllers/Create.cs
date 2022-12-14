using HotelRoomManager.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.Controllers
{
    public class Create
    {
        public ApplicationDbContext dbContext { get; set; }
        public Create(ApplicationDbContext context)
        {
            dbContext = context;
        }


        public void CreateNewRoom()
        {
            Console.Clear();
            var roomController = new RoomController();
            while (true)
            {
                try
                {
                    Console.WriteLine("Rumsvåning:");
                    var floor = Console.ReadLine();
                    var type = roomController.ControlCorrectRoomType();
                    Console.WriteLine("Rumstorlek (siffra i kvm):  ");
                    var size = Convert.ToInt32(Console.ReadLine());
                    var extraBed = roomController.ControlExtraBedsBySize(type, size);

                    dbContext.Room.Add(new Room()
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
                    Console.WriteLine("Felaktig inmatning, försök igen.");
                    Console.Clear();
                }
            }
            Console.WriteLine("Rum skapad.");
            Console.WriteLine($"{Environment.NewLine}Tryck på enter för att gå tillbaka till menyn.");
            Console.ReadKey();
        }





    }
}
