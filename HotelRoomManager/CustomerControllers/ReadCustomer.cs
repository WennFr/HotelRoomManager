using HotelRoomManager.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.CustomerControllers
{
    public class ReadCustomer
    {
        public ApplicationDbContext dbContext { get; set; }
        public ReadCustomer(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public bool ReadAllCustomers()
        {
            Console.WriteLine($"{Environment.NewLine}ID|Namn|Adress|Telefon {Environment.NewLine}");
            foreach (var customer in dbContext.Customers.Include(s => s.Salutation))
            {
                Console.WriteLine($"{customer.Id} |{customer.Salutation.SalutationType} {customer.FirstName} {customer.LastName}/{customer.Address}/{customer.Phone}");
                Console.WriteLine($"--|-------------------------------------------------------");
            }

            if (dbContext.Customers.Count() > 0)
                return true;
            return false;


        }


    }
}
