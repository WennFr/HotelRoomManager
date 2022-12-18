using HotelRoomManager.CustomerControllers;
using HotelRoomManager.Data;
using HotelRoomManager.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.BookingControllers
{
    public class DeleteBooking
    {
        public ApplicationDbContext dbContext { get; set; }
        public DeleteBooking(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void Delete()
        {

            Console.Clear();
            Console.WriteLine("Avboka");
            Console.WriteLine("======");

            var readBooking = new ReadBooking(dbContext);
            var bookingController = new BookingController(dbContext);

           var isAnyRegisteredBooking = readBooking.ReadAllBookings();

            if (!isAnyRegisteredBooking)
            {
                Message.NoRegisteredBookings();
                Message.PressEnterToReturnToMenu();
            }

            else
            {
                var bookingToDelete = bookingController.ChooseBooking();

                Console.Clear();
                Console.WriteLine(
                    $"{Environment.NewLine}BokningsID\tFrån\t\tTill\t\tKund\t\tRum {Environment.NewLine}");
                Console.WriteLine(
                    $"{bookingToDelete.Id}\t\t{bookingToDelete.StartDate.ToShortDateString()}\t{bookingToDelete.EndDate.ToShortDateString()} " +
                    $"\t{bookingToDelete.Customer.Salutation.SalutationType}{bookingToDelete.Customer.LastName}\t{bookingToDelete.Room.Id}");

                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{Environment.NewLine}Är du säker på att du vill ta bort den här bokningen? y/n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(">");
                    var selection = Console.ReadLine();

                    if (selection.ToLower() == "n" || selection.ToLower() == "no")
                    {
                        Message.PressEnterToReturnToMenu();
                        break;
                    }
                    else if (selection.ToLower() == "y" || selection.ToLower() == "yes")
                    {
                        dbContext.Bookings.Remove(bookingToDelete);
                        dbContext.SaveChanges();
                        Console.WriteLine($"{Environment.NewLine}Bokning borttagen.{Environment.NewLine}");
                        Message.PressEnterToReturnToMenu();
                        break;
                    }
                }

            }


        }
    }
}
