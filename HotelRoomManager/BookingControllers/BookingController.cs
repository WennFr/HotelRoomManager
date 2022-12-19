using HotelRoomManager.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRoomManager.Messages;

namespace HotelRoomManager.BookingControllers
{
    public class BookingController
    {
        public ApplicationDbContext dbContext { get; set; }
        public BookingController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public int ControlAmountOfGuests()
        {
            Console.WriteLine("Välj totalt antal gäster. Max 4 per rum.");
            int amountOfGuests;
            while (true)
            {
                Console.Write("> ");
                if (int.TryParse(Console.ReadLine(), out amountOfGuests) && amountOfGuests > 0 && amountOfGuests <= 4)
                    return amountOfGuests;

                Console.WriteLine("Du måste välja mellan 1-4 gäster.");
            }

        }

        public DateTime SelectStartDate()
        {
            Console.Clear();
            var todaysDate = DateTime.Now;
            Console.WriteLine($"Dagens datum: {todaysDate.ToShortDateString()} {Environment.NewLine}");
            Console.WriteLine("Vilket datum ska din bokning starta? (yyyy-mm-dd)");
            var startingDate = new DateTime(1995, 07, 03, 23, 59, 59);
            while (true)
            {
                Console.Write("> ");
                if (DateTime.TryParse(Console.ReadLine(), out startingDate) && startingDate >= DateTime.Now.Date)
                    return startingDate;

                Console.WriteLine("Ogiltigt datum, vänligen välj ett nytt.");
            }


        }
        public int SelectAmountOfNights()
        {
            Console.Clear();
            int amountOfNights;
            Console.WriteLine("Hur många nätter ska bokas?");
            while (true)
            {
                Console.Write(">");
                if (int.TryParse(Console.ReadLine(), out amountOfNights) && amountOfNights > 0)
                    return amountOfNights;

                Console.WriteLine("Ett rum måste bokas för minst en natt. Skriv in en siffra för antal nätter.");
            }
        }

        public List<Room> GetAllVacantRooms(List<DateTime> newBookingAllDates, int totalAmountOfGuests)
        {
            var availableRooms = new List<Room>();

            foreach (var room in dbContext.Rooms.ToList())
            {
                bool roomIsVacant = true;

                foreach (var booking in dbContext.Bookings.Include(b => b.Room).Where(b => b.Room == room))
                {
                    for (var dt = booking.StartDate; dt <= booking.EndDate; dt = dt.AddDays(1))
                    {
                        if (newBookingAllDates.Contains(dt) ||
                            booking.Room.Type == Convert.ToString(Room.RoomType.Single) && totalAmountOfGuests > 1 ||
                            booking.Room.Type == Convert.ToString(Room.RoomType.Double) && booking.Room.ExtraBed == 1 && totalAmountOfGuests == 4)
                        {
                            roomIsVacant = false;
                        }
                    }

                    if (!roomIsVacant)
                    {
                        break;
                    }
                }


                if (roomIsVacant && room.Type == Convert.ToString(Room.RoomType.Single) && totalAmountOfGuests > 1 ||
                    roomIsVacant && room.Type == Convert.ToString(Room.RoomType.Double) && room.ExtraBed == 1 && totalAmountOfGuests == 4)
                {
                    roomIsVacant = false;
                }


                else if (roomIsVacant)
                {
                    availableRooms.Add(room);
                }
            }

            return availableRooms;

        }

        public bool DisplayAllVacantRooms(List<Room> availableRooms)
        {
            if (availableRooms.Count() < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n Det finns inga lediga rum på valt datum. Ändra datum eller antal gäster ");
                Console.ForegroundColor = ConsoleColor.Gray;

                return false;
            }
            else
            {
                Console.WriteLine("\n\n\n Dessa rum är tillgängliga för bokning:");
                Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20}{4,-20}", $"{Environment.NewLine}RumsID", "Rumstyp", "Våning", "Storlek", $"Tillåtna extrasängar {Environment.NewLine}");
                foreach (var room in availableRooms.OrderBy(r => r.Size))
                {
                    Console.WriteLine("{0,-18} {1,-20} {2,-20} {3,-19} {4,-20}",
                        $"{room.Id}",
                        $"{room.Type}",
                        $"{room.Floor}",
                        $"{room.Size}kvm",
                        $"{room.ExtraBed}");
                    Console.WriteLine($"-----------------------------------------------------------------------------------------------------------");
                }
                return true;
            }
        }

        public Room ChooseVacantRoom(List<Room> availableRooms)
        {
            int intSelection;
            Console.WriteLine($"{Environment.NewLine}Välj Id på rummet du vill boka:");
            while (true)
            {
                Console.Write(">");
                if (int.TryParse(Console.ReadLine(), out intSelection) &&
                    availableRooms.Any(c => c.Id == intSelection))
                {
                    var roomSelection = dbContext.Rooms.FirstOrDefault(s => s.Id == intSelection);
                    Console.Clear();
                    return roomSelection;
                }

                Message.ChooseBetweenAvailableMenuNumbers();
            }

        }


        public void DisplayBookingDetails(Booking newBooking)
        {

            Console.Clear();
            Console.WriteLine("Bokningsdetaljer");
            Console.WriteLine("============================================================================================================");

            Console.WriteLine("{0,-15} {1,-15} {2,-24} {3,-15} {4,-15} {5,-15} ", $"{Environment.NewLine}Från", "Till", "Namn", $"RumsID", $"Rumstyp", $"Tillåtna extrasängar {Environment.NewLine}");
            Console.WriteLine("{0,-13} {1,-15} {2,-24} {3,-15} {4,-15} {5,-15} ",
                $"{newBooking.StartDate.ToShortDateString()}",
                $"{newBooking.EndDate.ToShortDateString()}",
                $"{newBooking.Customer.FirstName} {newBooking.Customer.LastName}",
                $"{newBooking.Room.Id}",
                $"{newBooking.Room.Type}",
                $"{newBooking.Room.ExtraBed}");
            Console.WriteLine($"-----------------------------------------------------------------------------------------------------------");





            //Console.WriteLine(" Från\t\tTill\t\tKund\t\tRum");
            //Console.WriteLine($" {newBooking.StartDate.ToShortDateString()}\t{newBooking.EndDate.ToShortDateString()}" +
            //                  $"\t{newBooking.Customer.FirstName} {newBooking.Customer.LastName}\t ID:{newBooking.Room.Id} Typ:{newBooking.Room.Type} Extrasängar:{newBooking.Room.ExtraBed}");

        }

        public Booking ChooseBooking()
        {
            int intSelection;
            Console.WriteLine($"Välj Id på den bokning du vill välja:");

            while (true)
            {
                Console.Write(">");
                if (int.TryParse(Console.ReadLine(), out intSelection) &&
                    dbContext.Bookings.Any(b => b.Id == intSelection))
                {
                    var booking = dbContext.Bookings.FirstOrDefault(b => b.Id == intSelection);
                    Console.Clear();
                    return booking;
                }

                Message.ChooseBetweenAvailableMenuNumbers();
            }

        }








    }
}
