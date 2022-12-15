using HotelRoomManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.Controllers
{
    public class Update
    {
        public ApplicationDbContext dbContext { get; set; }
        public Update(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public void UpdateCustomer()
        {
            Console.Clear();
            Console.WriteLine("Ändra kunduppgifter");
            Console.WriteLine($"=================== {Environment.NewLine}");

            var customerController = new CustomerController(dbContext);
            var read = new Read(dbContext);

            read.ReadAllCustomers();
            var customer = customerController.ChooseCustomer();

            var isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine($"Kund: {customer.Salutation.SalutationType} {customer.FirstName} {customer.LastName}|{customer.Address}|{customer.Phone}{Environment.NewLine}");
                Console.WriteLine("Vad vill du ändra?");
                Menu.UpdateCustomerSelectionMenu();

                var selectionMenuLimit = 4;
                var selection = MenuSelection.ValidateSelection(selectionMenuLimit);
                switch (selection)
                {
                    case 1:
                        customer.Salutation = customerController.ControlCustomerSalutation();
                        break;
                    case 2:
                        Console.WriteLine("Förnamn:");
                        customer.FirstName = Console.ReadLine();
                        Console.WriteLine("Efternamn:");
                        customer.LastName = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Adress:");
                        customer.Address = Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Telefon:");
                        customer.Phone = Console.ReadLine();
                        break;
                    case 5:
                        Console.WriteLine("Är du säker på att du vill radera?");


                        break;
                    case 0:
                        dbContext.SaveChanges();
                        Console.WriteLine("Ny kund sparad.");
                        Console.WriteLine($"{Environment.NewLine}Tryck på enter för att gå tillbaka till menyn.");
                        Console.ReadKey();
                        isRunning = false;
                        break;
                }
            }

        }
        public void UpdateRoom()
        {
            Console.Clear();
            Console.WriteLine("Ändra rum");
            Console.WriteLine($"=================== {Environment.NewLine}");
            var roomController = new RoomController(dbContext);
            var read = new Read(dbContext);

            read.ReadAllRooms();
            var room = roomController.ChooseRoom();

            var isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine($"Valt rum: {room.Id}|Våning:{room.Floor}|Rumstyp:{room.Type}|Storlek:{room.Size}kvm|Tillåtna extrasängar:{room.ExtraBed}{Environment.NewLine}");
                Console.WriteLine("Vad vill du ändra?");
                Menu.UpdateRoomSelectionMenu();

                var selectionMenuLimit = 3;
                var selection = MenuSelection.ValidateSelection(selectionMenuLimit);

                switch (selection)
                {
                    case 1:
                        Console.WriteLine("Våning:");
                        room.Floor = Console.ReadLine();
                        break;
                    case 2:
                        room.Type = roomController.ControlCorrectRoomType();
                        Console.WriteLine("Storlek:");
                        room.Size = validIntSelection();
                        room.ExtraBed = roomController.ControlExtraBedsByTypeAndSize(room.Type, room.Size);
                        break;
                    case 0:
                        dbContext.SaveChanges();
                        Console.WriteLine("Nytt rum sparat.");
                        Console.WriteLine($"{Environment.NewLine}Tryck på enter för att gå tillbaka till menyn.");
                        Console.ReadKey();
                        isRunning = false;
                        break;
                }
            }


        }
        public int validIntSelection()
        {
            int intSelection;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out intSelection))
                {
                    return intSelection;
                }
                Console.WriteLine("Du måste skriva in en siffra");
            }
        }


        public void UpdateBooking()
        {
        }
    }
}
