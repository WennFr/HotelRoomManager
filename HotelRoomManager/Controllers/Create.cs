using HotelRoomManager.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRoomManager.View;
using System.Runtime.ConstrainedExecution;

namespace HotelRoomManager.Controllers
{
    public class Create
    {
        public ApplicationDbContext dbContext { get; set; }
        public Create(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public void CreateNewRoom()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Registrera nytt rum");
                Console.WriteLine("===================");
                var roomController = new RoomController(dbContext);
                try
                {
                    Console.WriteLine($"{Environment.NewLine}Rumsvåning:");
                    var floor = Console.ReadLine();
                    var type = roomController.ControlCorrectRoomType();
                    Console.WriteLine($"{Environment.NewLine}Rumsstorlek (siffra i kvm):  ");
                    var size = Convert.ToInt32(Console.ReadLine());
                    var extraBed = roomController.ControlExtraBedsByTypeAndSize(type, size);
                    Console.WriteLine($"{Environment.NewLine}Antal tillåtna sängar sätts automatiskt efter rumsstorlek.");
                    Thread.Sleep(2000);
                    dbContext.Rooms.Add(new Room()
                    {
                        Floor = floor,
                        Type = type,
                        Size = size,
                        ExtraBed = extraBed
                    });
                    dbContext.SaveChanges();
                    break;
                }
                catch (Exception ex)
                {
                    //skapa message class
                    Console.WriteLine($"{Environment.NewLine}Felaktig inmatning, försök igen.");
                    Console.WriteLine($"{Environment.NewLine}Tryck på enter för starta om.");
                    Console.ReadKey();
                }
            }
            Console.WriteLine($"{Environment.NewLine}Nytt rum registrerat.");
            Console.WriteLine($"{Environment.NewLine}Tryck på enter för att gå tillbaka till menyn.");
            Console.ReadKey();
        }

        public void CreateNewCustomer()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Registrera ny kund");
                Console.WriteLine("==================");
                var customerController = new CustomerController(dbContext);
                try
                {
                    Console.WriteLine($"{Environment.NewLine}Välj titel:");
                    var salutationInput = customerController.ControlCustomerSalutation();
                    Console.WriteLine($"{Environment.NewLine}Förnamn:");
                    var firstName = Console.ReadLine();
                    Console.WriteLine($"{Environment.NewLine}Efternamn:");
                    var lastName = Console.ReadLine();
                    Console.WriteLine($"{Environment.NewLine}Adress:");
                    var address = Console.ReadLine();
                    Console.WriteLine($"{Environment.NewLine}Telefon:");
                    var phone = Console.ReadLine();

                    dbContext.Customers.Add(new Customer()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Address = address,
                        Phone = phone,
                        Salutation = salutationInput
                    });
                    dbContext.SaveChanges();
                    break;
                }
                catch (Exception ex)
                {
                    //skapa message class
                    Console.WriteLine($"{Environment.NewLine}Felaktig inmatning, försök igen.");
                    Console.WriteLine($"{Environment.NewLine}Tryck på enter för starta om.");
                    Console.ReadKey();
                }

            }
            Console.WriteLine($"{Environment.NewLine}Ny kund registrerad.");
            Console.WriteLine($"{Environment.NewLine}Tryck på enter för att gå tillbaka till menyn.");
            Console.ReadKey();
        }

        public void CreateNewBooking()
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

            List<Room> availableRooms = bookingController.GetAllVacantRooms(newBookingAllDates,totalAmountOfGuests);

            var roomIsAvailable = bookingController.DisplayAllVacantRooms(availableRooms);

            if (!roomIsAvailable)
                Menu.BookingMenu();

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
                        var read = new Read(dbContext);
                        read.ReadAllCustomers();
                        customerToBook = customerController.ChooseCustomer();
                        break;

                    case 2:
                        CreateNewCustomer();
                        continue;

                    default:
                        continue;
                }

                break;
            }

            newBooking.Room = roomToBook;
            newBooking.Customer = customerToBook;

            bookingController.DisplayBookingDetails(newBooking);

            Console.WriteLine($"{Environment.NewLine}Vill du bekräfta bokningen?");
            Console.WriteLine("1) Bekräfta bokning");
            Console.WriteLine("0) Avbryt bokning");

             selectionMenuLimit = 1;
             selection = MenuSelection.ValidateSelection(selectionMenuLimit);

             switch (selection)
             {
                case 1:
                    dbContext.Add(newBooking);
                    dbContext.SaveChanges();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Clear();
                    Console.WriteLine(" Bokningen lyckades!");
                    Console.WriteLine(" ==============================================================================");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\n Tryck på enter för att gå tillbaka till menyn");
                    Console.ReadLine();
                    break;

                case 0:
                    Console.WriteLine("Bokningen är avbruten.");
                    Console.WriteLine("\n Tryck på enter för att gå tillbaka till menyn");
                    Console.ReadLine();
                    break;
             }

        }






    }
}
