using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace HotelRoomManager.Models
{
    public class Menu
    {
        public static void MainMenu()
        {
            var isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("1) Bokningar");
                Console.WriteLine("2) Registreringar");
                Console.WriteLine("3) Ändra i systemet");
                Console.WriteLine("0) Avsluta applikationen");

               isRunning =  MenuSelection.Main();
            }

        }
        public static void BookingMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1) Boka rum");
                Console.WriteLine("2) Ändra en bokning");
                Console.WriteLine("3) Sök efter lediga rum på datum ");
                Console.WriteLine("0) Gå tillbaka");

                MenuSelection.Booking();
            }

        }
        public static void RegistrationMenu()
        {
            Console.Clear();
            Console.WriteLine("1) Registrera nytt rum");
            Console.WriteLine("2) Registrera ny kund");
            Console.WriteLine("0) Gå tillbaka");

            MenuSelection.Registration();

        }


    }
}
