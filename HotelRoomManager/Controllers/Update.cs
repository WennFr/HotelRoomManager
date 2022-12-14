using HotelRoomManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.Controllers
{
    public class Update
    {
        private Read read;
        public ApplicationDbContext dbContext { get; set; }
        public Update(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void UpdateCustomer()
        {
            Console.WriteLine("Ändra kunduppgifter");
            Console.WriteLine("===================");
            read = new Read(dbContext);
            read.ReadAllCustomers();

            Console.ReadKey();



        }



    }
}
