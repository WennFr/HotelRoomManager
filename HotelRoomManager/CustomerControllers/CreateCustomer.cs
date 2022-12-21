using HotelRoomManager.Data;
using HotelRoomManager.Messages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.CustomerControllers
{
    public class CreateCustomer
    {
        public ApplicationDbContext dbContext { get; set; }
        public CreateCustomer(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void Create()
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
                    Message.WrongInput();
                    Message.PressEnter();
                    continue;
                }

            }
            Console.WriteLine($"{Environment.NewLine}Ny kund registrerad.");
            Message.PressEnterToReturnToMenu();
        }






    }
}
