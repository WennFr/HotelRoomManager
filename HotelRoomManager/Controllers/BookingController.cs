using HotelRoomManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.Controllers
{
    public class BookingController
    {

        public ApplicationDbContext dbContext { get; set; }
        public BookingController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public int ControlAmountOfGuests()
        {
            Console.WriteLine("Välj totalt antal gäster. Max 4 per rum.");
            int amountOfGuests;
            while (true)
            {
                Console.Write("> ");
                if (int.TryParse(Console.ReadLine(), out amountOfGuests) && amountOfGuests > 0 && amountOfGuests <= 4)
                    return amountOfGuests;

                Console.WriteLine("Du måste välja mellan 1-4 gäster.");
            }

        }


        public DateTime SelectStartDate()
        {
            Console.Clear();
            var todaysDate = DateTime.Now;
            Console.WriteLine($"Dagens datum: {todaysDate.ToShortDateString()} {Environment.NewLine}");
            Console.WriteLine("Vilket datum ska din bokning starta? (yyyy-mm-dd)");
            var startingDate = new DateTime(1995, 07, 03, 23, 59, 59);
            while (true)
            {
                Console.Write("> ");
                if (DateTime.TryParse(Console.ReadLine(), out startingDate) && startingDate >= DateTime.Now.Date)
                    return startingDate;

                Console.WriteLine("Ogiltigt datum, vänligen välj ett nytt.");
            }


        }

        public int SelectAmountOfNights()
        {
            Console.Clear();
            int amountOfNights;
            Console.WriteLine("Hur många nätter vill ni boka?");
            while (true)
            {
                Console.WriteLine(">");
                if (int.TryParse(Console.ReadLine(), out amountOfNights))
                    return amountOfNights;

                Console.WriteLine("Du måste skriva in en siffra");
            }
        }






    }
}
