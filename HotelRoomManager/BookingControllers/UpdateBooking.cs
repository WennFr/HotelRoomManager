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

            var isAnyRegisteredBooking = readBooking.ReadAllBookings();

            if (!isAnyRegisteredBooking)
            {
                Message.NoRegisteredBookings();
                Message.PressEnterToReturnToMenu();
            }


            else
            {
                var currentBooking = bookingController.ChooseBooking();
                var isRunning = true;
                while (isRunning)
                {
                    Console.Clear();
                    Console.WriteLine(
                        $"{Environment.NewLine}BokningsID\tFrån\t\tTill\t\tKund\t\tRum {Environment.NewLine}");
                    Console.WriteLine(
                        $"{currentBooking.Id}\t\t{currentBooking.StartDate.ToShortDateString()}\t{currentBooking.EndDate.ToShortDateString()} " +
                        $"\t{currentBooking.Customer.Salutation.SalutationType}{currentBooking.Customer.LastName}\t{currentBooking.Room.Id}");
                    Console.WriteLine($"{Environment.NewLine}Vad vill du ändra? {Environment.NewLine}");
                    Menu.UpdateBookingSelectionMenu();

                    var selectionMenuLimit = 3;
                    var selection = MenuSelection.ValidateSelection(selectionMenuLimit);

                    switch (selection)
                    {
                        case 1:
                            var customerController = new CustomerController(dbContext);
                            var readCustomer = new ReadCustomer(dbContext);
                            Console.Clear();
                            readCustomer.ReadAllCustomers();
                            var customer = customerController.ChooseCustomer();
                            currentBooking.Customer = customer;
                            dbContext.SaveChanges();
                            Console.WriteLine("Ny kund registrerad på bokningen.");
                            break;

                        case 2:

                            Console.Clear();
                            Console.WriteLine("Boka nytt rum");

                            var totalAmountOfGuests = bookingController.ControlAmountOfGuests();

                            List<DateTime> newBookingAllDates = new List<DateTime>();
                            for (var dt = currentBooking.StartDate; dt <= currentBooking.EndDate; dt = dt.AddDays(1))
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
                                currentBooking.Room = roomToBook;
                                dbContext.SaveChanges();
                                Message.NewBookedRoomUpdated();
                            }
                            break;

                        case 3:

                            Console.WriteLine("Ändra datum:");

                            var backUpStartDate = currentBooking.StartDate;
                            var backUpEndDate = currentBooking.EndDate;

                            //Original booking dates needs to be reset.
                            currentBooking.StartDate = new DateTime(1995, 07, 03, 23, 59, 59);
                            currentBooking.EndDate = new DateTime(1995, 07, 03, 23, 59, 59);

                            var amountOfBookedNights = bookingController.SelectAmountOfNights();
                            var startDate = bookingController.SelectStartDate();
                            var endDate = new DateTime(1995, 07, 03, 23, 59, 59);
                            if (amountOfBookedNights > 0) endDate = startDate.AddDays(amountOfBookedNights);

                            newBookingAllDates = new List<DateTime>();
                            for (var dt = startDate; dt <= endDate; dt = dt.AddDays(1))
                                newBookingAllDates.Add(dt);

                            var isNewDateValid = bookingController.IsNewDateValid(currentBooking.Room, newBookingAllDates);

                            if (!isNewDateValid)
                            {
                                currentBooking.StartDate = backUpStartDate;
                                currentBooking.EndDate = backUpEndDate;
                                Console.WriteLine("Rummet är bokat på dessa datum. Var god prova ett annat datum.");
                                Message.PressEnter();
                            }
                            else
                            {
                                currentBooking.StartDate = startDate;
                                currentBooking.EndDate = endDate;
                                dbContext.SaveChanges();
                                Message.NewBookingDateUpdated();
                                Message.PressEnter();
                            }

                            break;


                        case 0:
                            dbContext.SaveChanges();
                            Message.ChangesSaved();
                            Message.PressEnterToReturnToMenu();
                            isRunning = false;
                            break;
                    }
                }



            }

        }


    }


}

