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
    public class UpdateBooking
    {
        public ApplicationDbContext dbContext { get; set; }

        public UpdateBooking(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void Update()
        {

            Console.Clear();
            Console.WriteLine("Ändra bokning");
            Console.WriteLine("=============");

            var bookingController = new BookingController(dbContext);
            var readBooking = new ReadBooking(dbContext);

            readBooking.ReadAllBookings();
            var booking = bookingController.ChooseBooking();

            var isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine($"{Environment.NewLine}BokningsID\tFrån\t\tTill\t\tKund\t\tRum {Environment.NewLine}");
                Console.WriteLine($"{booking.Id}\t\t{booking.StartDate.ToShortDateString()}\t{booking.EndDate.ToShortDateString()} " +
                                  $"\t{booking.Customer.Salutation.SalutationType}{booking.Customer.LastName}\t{booking.Room.Id}");
                Console.WriteLine($"{Environment.NewLine}Vad vill du ändra? {Environment.NewLine}");
                Menu.UpdateBookingSelectionMenu();

                var selectionMenuLimit = 2;
                var selection = MenuSelection.ValidateSelection(selectionMenuLimit);

                switch (selection)
                {
                    case 1:
                        var customerController = new CustomerController(dbContext);
                        var readCustomer = new ReadCustomer(dbContext);
                        Console.Clear();
                        readCustomer.ReadAllCustomers();
                        var customer = customerController.ChooseCustomer();
                        booking.Customer = customer;
                        dbContext.SaveChanges();
                        Console.WriteLine("Ny kund registrerad på bokningen.");
                        break;
                    case 2:
                        Console.Clear();
                        booking.StartDate = new DateTime(1995, 07, 03, 23, 59, 59);
                        booking.EndDate = new DateTime(1995, 07, 03, 23, 59, 59);


                        var totalAmountOfGuests = bookingController.ControlAmountOfGuests();
                        var amountOfBookedNights = bookingController.SelectAmountOfNights();
                        var startDate = bookingController.SelectStartDate();
                        var endDate = new DateTime(1995, 07, 03, 23, 59, 59);


                        if (amountOfBookedNights > 0) endDate = startDate.AddDays(amountOfBookedNights);

                        List<DateTime> newBookingAllDates = new List<DateTime>();
                        for (var dt = startDate; dt <= endDate; dt = dt.AddDays(1))
                            newBookingAllDates.Add(dt);

                        List<Room> availableRooms = bookingController.GetAllVacantRooms(newBookingAllDates, totalAmountOfGuests);

                        var roomIsAvailable = bookingController.DisplayAllVacantRooms(availableRooms);

                        if (!roomIsAvailable)
                        {
                            Console.WriteLine("Tryck på enter.");
                            Console.ReadKey();
                        }

                        else
                        {
                            var roomToBook = bookingController.ChooseVacantRoom(availableRooms);
                            booking.Room = roomToBook;
                            booking.StartDate = startDate;
                            booking.EndDate = endDate;
                        }
                        break;

                    case 0:
                        dbContext.SaveChanges();
                        Console.WriteLine("Bokning ändrad.");
                        Message.PressEnterToReturnToMenu();
                        isRunning = false;
                        break;
                }
            }

        }


        





    }


}

