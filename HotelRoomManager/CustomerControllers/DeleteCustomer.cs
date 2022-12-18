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
            Console.Clear();
            Console.WriteLine("Radera Kund");
            Console.WriteLine("===========");


            var readCustomers = new ReadCustomer(dbContext);
            var customerController = new CustomerController(dbContext);

            var isAnyRegisteredCustomer = readCustomers.ReadAllCustomers();

            if (!isAnyRegisteredCustomer)
            {
                Message.NoRegisteredCustomers();
                Message.PressEnterToReturnToMenu();

            }

            else
            {
                var customerToDelete = customerController.ChooseCustomer();
                var isCustomerBooked = customerController.CheckIfCustomerIsBooked(customerToDelete);

                if (isCustomerBooked)
                {
                    Message.CustomerIsBooked();
                    Message.PressEnterToReturnToMenu();
                }

                else
                {
                    Console.WriteLine($"{Environment.NewLine}ID|Namn|Adress|Telefon {Environment.NewLine}");
                    Console.WriteLine(
                        $"Kund: {customerToDelete.Id} |{customerToDelete.Salutation.SalutationType} {customerToDelete.FirstName} {customerToDelete.LastName}/{customerToDelete.Address}/{customerToDelete.Phone} {Environment.NewLine}");

                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Är du säker på att du vill ta bort den här kunden? y/n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(">");
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
}
