using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.Messages
{
    public static class Message
    {
        public static void NoRegisteredRooms()
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Det finns inga registrerade rum i systemet.");
            Console.ForegroundColor = ConsoleColor.Gray;

        }

        public static void NoRegisteredCustomers()
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Det finns inga registrerade kunder i systemet.");
            Console.ForegroundColor = ConsoleColor.Gray;

        }



        public static void NoRegisteredBookings()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Det finns inga nuvarande bokningar i systemet.");
            Console.ForegroundColor = ConsoleColor.Gray;


        }

        public static void CustomerIsBooked()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Kunden som har valts har en pågående bokning. Kunden går inte att radera så länge bokningen är aktiv. ");
            Console.ForegroundColor = ConsoleColor.Gray;


        }

        public static void ChooseBetweenAvailableMenuNumbers()
        {
            Console.WriteLine("Välj mellan de angivna siffrorna i menyn");
        }

        public static void PressEnterToReturnToMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{Environment.NewLine}Tryck på enter för att gå tillbaka till menyn.");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();

        }

        public static void WrongInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{Environment.NewLine}Felaktig inmatning, försök igen.");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{Environment.NewLine}Tryck på enter för starta om.");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();

        }


    }
}
