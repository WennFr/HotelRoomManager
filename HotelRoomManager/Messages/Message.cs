using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.Messages
{
    public static class Message
    {


        public static void ChangesSaved()
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ändringar sparade!");
            Console.ForegroundColor = ConsoleColor.Gray;

        }

        public static void PressEnter()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Tryck på enter.");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
        }



        public static void NewBookedRoomUpdated()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Environment.NewLine}Nytt rum bokat!");
            Console.ForegroundColor = ConsoleColor.Gray;

        }

        public static void NewBookingDateUpdated()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Nytt datum satt!");
            Console.ForegroundColor = ConsoleColor.Gray;

        }


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


        public static void RoomIsBooked()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Rummet som har valts har en pågående bokning.");
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

            
        }


    }
}
