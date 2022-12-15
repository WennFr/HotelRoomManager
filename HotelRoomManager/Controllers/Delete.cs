using HotelRoomManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.Controllers
{
    public class Delete
    {
        public ApplicationDbContext dbContext { get; set; }
        public Delete(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void DeleteEntity()
        {
            Menu.DeleteSelectionMenu();
            var selectionMenuLimit = 3;
            var selection = MenuSelection.ValidateSelection(selectionMenuLimit);

            switch (selection)
            {
                case 1:
                    DeleteRoom();
                    break;
                case 2:
                    DeleteCustomer();
                    break;
                case 3:
                    DeleteBooking();
                    break;
                case 0:
                    break;
            }
        }

        public void DeleteCustomer()
        {
            var read = new Read(dbContext);
            var customerController = new CustomerController(dbContext);

            read.ReadAllCustomers();
            var customerToDelete = customerController.ChooseCustomer();
            Console.WriteLine($"Kund: {customerToDelete.Id} {customerToDelete.FirstName} {customerToDelete.LastName} {Environment.NewLine}");


            while (true)
            {
                Console.WriteLine($"Är du säker på att du vill ta bort den här kunden? y/n");
                var selection = Console.ReadLine();

                if (selection.ToLower() == "n" || selection.ToLower() == "no")
                    break;

                else if (selection.ToLower() == "y" || selection.ToLower() == "yes")
                {
                    dbContext.Customers.Remove(customerToDelete);
                    dbContext.SaveChanges();
                    Console.WriteLine("Kund raderad.");
                    Console.WriteLine($"{Environment.NewLine}Tryck på enter för att fortsätta.");
                    Console.ReadKey();
                    break;
                }


            }



        }

        public void DeleteRoom()
        {




        }


        public void DeleteBooking()
        {




        }



    }
}
