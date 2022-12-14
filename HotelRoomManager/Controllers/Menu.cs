using HotelRoomManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace HotelRoomManager.Controllers
{
    public static class Menu
    {
        public static void MainMenu()
        {
            var isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine($"Huvudmeny {Environment.NewLine}");
                Console.WriteLine("1) Bokningar");
                Console.WriteLine("2) Registreringar");
                Console.WriteLine("3) Ändra uppgifter i systemet");
                Console.WriteLine("0) Avsluta applikationen");

                isRunning = MenuSelection.Main();
            }

        }
        public static void BookingMenu()
        {
            Console.Clear();
            Console.WriteLine($"Bokningar {Environment.NewLine}");
            Console.WriteLine("1) Boka rum");
            Console.WriteLine("2) Ändra en bokning");
            Console.WriteLine("3) Sök på datum efter lediga rum");
            Console.WriteLine("0) Gå tillbaka");

            MenuSelection.Booking();

        }
        public static void RegistrationMenu()
        {
            Console.Clear();
            Console.WriteLine($"Registreringar {Environment.NewLine}");
            Console.WriteLine("1) Registrera nytt rum");
            Console.WriteLine("2) Registrera ny kund");
            Console.WriteLine("0) Gå tillbaka");

            MenuSelection.Registration();
        }

        public static void EditSystemDataMenu()
        {
            Console.Clear();
            Console.WriteLine($"Ändra uppgifter i systemet{Environment.NewLine}");
            Console.WriteLine("1) Ändra rum");
            Console.WriteLine("2) Ändra kunduppgifter");
            Console.WriteLine("3) Ändra en bokning");
            Console.WriteLine("0) Gå tillbaka");

            MenuSelection.Registration();

        }


    }
}
