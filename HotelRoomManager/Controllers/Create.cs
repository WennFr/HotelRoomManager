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
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Registrera nytt rum");
                Console.WriteLine("===================");
                var roomController = new RoomController();
                try
                {
                    Console.WriteLine($"{Environment.NewLine}Rumsvåning:");
                    var floor = Console.ReadLine();
                    var type = roomController.ControlCorrectRoomType();
                    Console.WriteLine($"{Environment.NewLine}Rumsstorlek (siffra i kvm):  ");
                    var size = Convert.ToInt32(Console.ReadLine());
                    var extraBed = roomController.ControlExtraBedsByTypeAndSize(type, size);
                    Console.WriteLine($"{Environment.NewLine}Antal tillåtna sängar sätts automatiskt efter rumsstorlek.  ");
                    Thread.Sleep(2000);
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
                    //skapa message class
                    Console.WriteLine($"{Environment.NewLine}Felaktig inmatning, försök igen.");
                    Console.WriteLine($"{Environment.NewLine}Tryck på enter för starta om.");
                    Console.ReadKey();
                }
            }
            Console.WriteLine($"{Environment.NewLine}Rum skapat.");
            Console.WriteLine($"{Environment.NewLine}Tryck på enter för att gå tillbaka till menyn.");
            Console.ReadKey();
        }

        public void CreateNewCustomer()
        {






        }






    }
}
