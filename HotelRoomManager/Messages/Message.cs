using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.Messages
{
    public static class Message
    {
        public static void NoCurrentBookings()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Det finns inga nuvarande bokningar i systemet.");
            Console.ForegroundColor = ConsoleColor.Gray;


        }


        public static void ChooseBetweenAvailableMenuNumbers()
        {
            Console.WriteLine("Välj mellan de angivna siffrorna i menyn");
        }

        public static void PressEnterToReturnToMenu()
        {
            Console.WriteLine($"{Environment.NewLine}Tryck på enter för att gå tillbaka till menyn.");
            Console.ReadKey();

        }

        public static void WrongInput()
        {

            Console.WriteLine($"{Environment.NewLine}Felaktig inmatning, försök igen.");
            Console.WriteLine($"{Environment.NewLine}Tryck på enter för starta om.");
            Console.ReadKey();

        }


    }
}
