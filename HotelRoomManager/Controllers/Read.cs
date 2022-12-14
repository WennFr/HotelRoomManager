using HotelRoomManager.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.Controllers
{
    public class Read
    {
        public ApplicationDbContext dbContext { get; set; }
        public Read(ApplicationDbContext context)
        {
            dbContext = context;
        }


        public void ReadAllCustomers()
        {
            foreach (var customer in dbContext.Customer.Include(s=> s.SalutationId))
            {
                Console.WriteLine($"{customer.Id} {customer.SalutationId.sa} {customer.FirstName} {customer.LastName}");
                Console.WriteLine("===============================================================================");
            }

        }


    }
}
