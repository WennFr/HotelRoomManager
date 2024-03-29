﻿using HotelRoomManager.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRoomManager.Messages;

namespace HotelRoomManager.CustomerControllers
{
    public class CustomerController
    {
        public ApplicationDbContext dbContext { get; set; }
        public CustomerController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public Salutation ControlCustomerSalutation()
        {
            int intSelection;
            foreach (var salutation in dbContext.Salutations)
                Console.WriteLine($"{salutation.Id} - {salutation.SalutationType}");

            while (true)
            {
                Console.Write(">");
                if (int.TryParse(Console.ReadLine(), out intSelection) &&
                    dbContext.Salutations.Any(s => s.Id == intSelection))
                {
                    var salutation = dbContext.Salutations.FirstOrDefault(s => s.Id == intSelection);
                    return salutation;
                }

                Message.ChooseBetweenAvailableMenuNumbers();

            }

        }
        public Salutation GetMaleSalutation()
        {
            var salutation = dbContext.Salutations.FirstOrDefault(s => s.Id == 1);
            return salutation;
        }

        public Salutation GetFemaleSalutation()
        {
            var salutation = dbContext.Salutations.FirstOrDefault(s => s.Id == 2);
            return salutation;
        }


        public Customer ChooseCustomer()
        {
            int intSelection;
            Console.WriteLine($"Välj Id på den kund du vill selektera:");

            while (true)
            {
                Console.WriteLine(">");
                if (int.TryParse(Console.ReadLine(), out intSelection) &&
                    dbContext.Customers.Any(c => c.Id == intSelection))
                {
                    var customer = dbContext.Customers.FirstOrDefault(s => s.Id == intSelection);
                    Console.Clear();
                    return customer;
                }

                Message.ChooseBetweenAvailableMenuNumbers();
            }

        }



        public bool CheckIfCustomerIsBooked(Customer customerToDelete)
        {
            foreach (var booking in dbContext.Bookings.Include(b => b.Customer).Where(b => b.Customer == customerToDelete))
                if (booking.Customer == customerToDelete)
                    return true;
            return false;
        }


        public void DisplayChosenCustomer(Customer customer)
        {
            Console.WriteLine("{0,-17} {1,-15} {2,-25} {3,-20}{4,-20} ", $"{Environment.NewLine}KundID", "Titel", "Namn", "Adress", $"Telefon{Environment.NewLine}");
            Console.WriteLine("{0,-15} {1,-15} {2,-25} {3,-20}{4,-20}",
                $"{customer.Id}",
                $"{customer.Salutation.SalutationType}",
                $"{customer.FirstName} {customer.LastName}",
                $"{customer.Address}",
                $"{customer.Phone}{Environment.NewLine}");

        }


    }
}
