using HotelRoomManager.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.Controllers
{
    public class CustomerController
    {
        public ApplicationDbContext dbContext { get; set; }
        public CustomerController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public Salutation ControlCustomerSalutation()
        {
            int intSelection;
            Console.WriteLine($"{Environment.NewLine}Välj titel:");

            foreach (var salutation in dbContext.Salutation)
                Console.WriteLine($"{salutation.Id} - {salutation.SalutationType}");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out intSelection) &&
                    dbContext.Salutation.Any(s => s.Id == intSelection))
                {
                    var salutation = dbContext.Salutation.FirstOrDefault(s => s.Id == intSelection);
                    return salutation;
                }

                Console.WriteLine("Välj mellan de angivna siffrorna i menyn");
            }

        }

        public Salutation GetMaleSalutation()
        {
            var salutation = dbContext.Salutation.FirstOrDefault(s => s.Id == 1);
            return salutation;
        }

        public Salutation GetFemaleSalutation()
        {
            var salutation = dbContext.Salutation.FirstOrDefault(s => s.Id == 2);
            return salutation;
        }


        public Customer ChooseCustomer()
        {
            int intSelection;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out intSelection) &&
                    dbContext.Customer.Any(c => c.Id == intSelection))
                {
                    var customer = dbContext.Customer.FirstOrDefault(s => s.Id == intSelection);
                    Console.Clear();
                    return customer;
                }

                Console.WriteLine("Välj mellan de angivna siffrorna i menyn");
            }

        }







    }
}
