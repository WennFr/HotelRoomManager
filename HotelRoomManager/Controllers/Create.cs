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
            var room = new Room();

            Console.WriteLine("Kursnamn:");
            room.Floor = Console.ReadLine();
            room.Type = Console.ReadLine();

                dbContext.Room.Add(room);
                dbContext.SaveChanges();
            

            Console.WriteLine("Rum skapad.");
            Console.ReadKey();
        }





    }
}
