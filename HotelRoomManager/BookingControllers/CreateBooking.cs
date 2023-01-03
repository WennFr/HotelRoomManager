using HotelRoomManager.CustomerControllers;
using HotelRoomManager.Data;
using HotelRoomManager.Menus;
using HotelRoomManager.Messages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.BookingControllers
{
    public class CreateBooking
    {

        public ApplicationDbContext dbContext { get; set; }
        public CreateBooking(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void Create()
        {
            Console.Clear();
            Console.WriteLine($"Ny Bokning");
            Console.WriteLine($"========== {Environment.NewLine}");

            var newBooking = new Booking();
            var bookingController = new BookingController(dbContext);

            var totalAmountOfGuests = bookingController.ControlAmountOfGuests();
            var amountOfBookedNights = bookingController.SelectAmountOfNights();
            newBooking.StartDate = bookingController.SelectStartDate();

            if (amountOfBookedNights > 0) newBooking.EndDate = newBooking.StartDate.AddDays(amountOfBookedNights);

            List<DateTime> newBookingAllDates = new List<DateTime>();
            for (var dt = newBooking.StartDate; dt <= newBooking.EndDate; dt = dt.AddDays(1))
                newBookingAllDates.Add(dt);

            List<Room> availableRooms = bookingController.GetAllVacantRooms(newBookingAllDates, totalAmountOfGuests);

            var roomIsAvailable = bookingController.DisplayAllVacantRooms(availableRooms);

            if (!roomIsAvailable)
            {
                Message.PressEnterToReturnToMenu();
            }

            else
            {
                var roomToBook = bookingController.ChooseVacantRoom(availableRooms);
                Customer customerToBook = new Customer();

                var selectionMenuLimit = 0;
                var selection = 0;

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("1) Välj kund för att skapa bokning");
                    Console.WriteLine("2) Registrera ny kund");

                    selectionMenuLimit = 2;
                    selection = MenuSelection.ValidateSelection(selectionMenuLimit);

                    var customerController = new CustomerController(dbContext);


                    switch (selection)
                    {
                        case 1:
                            var readCustomers = new ReadCustomer(dbContext);
                            readCustomers.ReadAllCustomers();
                            customerToBook = customerController.ChooseCustomer();
                            break;

                        case 2:
                            var createCustomer = new CreateCustomer(dbContext);
                            createCustomer.Create();
                            continue;

                        default:
                            Message.ChooseBetweenAvailableMenuNumbers();
                            continue;
                    }

                    break;
                }

                newBooking.Room = roomToBook;
                newBooking.Customer = customerToBook;

                bookingController.DisplayBookingDetails(newBooking);

                Console.WriteLine($"{Environment.NewLine}Vill du bekräfta bokningen?");
                Console.WriteLine("1) Bekräfta bokning");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("0) Avbryt bokning");
                Console.ForegroundColor = ConsoleColor.Gray;

                selectionMenuLimit = 1;
                selection = MenuSelection.ValidateSelection(selectionMenuLimit);

                switch (selection)
                {
                    case 1:
                        dbContext.Add(newBooking);
                        dbContext.SaveChanges();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Clear();
                        Console.WriteLine("Bokningen lyckades!");
                        Console.WriteLine(
                            "==============================================================================");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Message.PressEnterToReturnToMenu();
                        break;

                    case 0:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bokningen är avbruten.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Message.PressEnterToReturnToMenu();
                        break;
                }


            }

        }




    }
}
