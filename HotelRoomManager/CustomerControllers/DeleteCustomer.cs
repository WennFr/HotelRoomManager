using HotelRoomManager.Data;
using HotelRoomManager.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.CustomerControllers
{
    public class DeleteCustomer
    {
        public ApplicationDbContext dbContext { get; set; }
        public DeleteCustomer(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void Delete()
        {
            var readCustomers = new ReadCustomer(dbContext);
            var customerController = new CustomerController(dbContext);

            readCustomers.ReadAllCustomers();
            var customerToDelete = customerController.ChooseCustomer();

            var isCustomerBooked = customerController.CheckIfCustomerIsBooked(customerToDelete);

            if (isCustomerBooked)
            {
                Console.WriteLine("Kunden som har valts har en pågående bokning. Kunden går inte att radera så länge bokningen är aktiv. ");
                Message.PressEnterToReturnToMenu();
            }

            else
            {
                Console.WriteLine(
                    $"Kund: {customerToDelete.Id} {customerToDelete.FirstName} {customerToDelete.LastName} {Environment.NewLine}");


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
                        Console.WriteLine($"Kund raderad.{Environment.NewLine}");
                        Message.PressEnterToReturnToMenu();
                        break;
                    }
                }


            }



        }





    }
}
