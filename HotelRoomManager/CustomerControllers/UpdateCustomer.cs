using HotelRoomManager.Controllers;
using HotelRoomManager.Data;
using HotelRoomManager.Menus;
using HotelRoomManager.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.CustomerControllers
{
    public class UpdateCustomer
    {
        public ApplicationDbContext dbContext { get; set; }
        public UpdateCustomer(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void Update()
        {
            Console.Clear();
            Console.WriteLine("Ändra kunduppgifter");
            Console.WriteLine($"=================== {Environment.NewLine}");

            var customerController = new CustomerController(dbContext);
            var readCustomers = new ReadCustomer(dbContext);

            readCustomers.ReadAllCustomers();
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
                    case 0:
                        dbContext.SaveChanges();
                        Console.WriteLine("Ny kund sparad.");
                        Message.PressEnterToReturnToMenu();
                        isRunning = false;
                        break;
                }
            }

        }




    }
}
