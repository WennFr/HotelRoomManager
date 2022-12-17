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
                Console.WriteLine("Vad vill du ändra?");
                Menu.UpdateBookingSelectionMenu();

                var selectionMenuLimit = 2;
                var selection = MenuSelection.ValidateSelection(selectionMenuLimit);

                switch (selection)
                {
                    case 1:
                        var customerController = new CustomerController(dbContext);
                        var customer = customerController.ChooseCustomer();
                        booking.Customer = customer;
                        dbContext.SaveChanges();
                        Console.WriteLine("Ny kund registrerad på bokningen.");
                        Message.PressEnterToReturnToMenu();
                        break;
                    case 2:

                        var totalAmountOfGuests = bookingController.ControlAmountOfGuests();
                        var amountOfBookedNights = bookingController.SelectAmountOfNights();
                        booking.StartDate = bookingController.SelectStartDate();
                        if (amountOfBookedNights > 0) booking.EndDate = booking.StartDate.AddDays(amountOfBookedNights);
                        List<DateTime> newBookingAllDates = new List<DateTime>();
                        for (var dt = booking.StartDate; dt <= booking.EndDate; dt = dt.AddDays(1))
                            newBookingAllDates.Add(dt);

                        List<Room> availableRooms = bookingController.GetAllVacantRooms(newBookingAllDates, totalAmountOfGuests);

                        var roomIsAvailable = bookingController.DisplayAllVacantRooms(availableRooms);

                        if (!roomIsAvailable)
                        {
                          
                        }

                        else
                        {
                            var roomToBook = bookingController.ChooseVacantRoom(availableRooms);
                            booking.Room = roomToBook;
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

