﻿using HotelRoomManager.Data;
using HotelRoomManager.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRoomManager.Messages;

namespace HotelRoomManager.Controllers
{
    public class Delete
    {
        public ApplicationDbContext dbContext { get; set; }
        public Delete(ApplicationDbContext context)
        {
            dbContext = context;
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
                    Console.WriteLine($"Kund raderad.{Environment.NewLine}");
                    Message.PressEnterToReturnToMenu();
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
