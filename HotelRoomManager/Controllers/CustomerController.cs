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


        public int ControlCustomerSalutation()
        {
            int intSelection;
            Console.WriteLine($"{Environment.NewLine}Välj titel:");

            foreach (var salutation in dbContext.Salutation)
                Console.WriteLine($"{salutation.Id} - {salutation.SalutationType}");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out intSelection) && dbContext.Salutation.Any(s=> s.Id == intSelection))
                    return intSelection;

                Console.WriteLine("Välj mellan de angivna siffrorna i menyn");
            }



        }







    }
}
