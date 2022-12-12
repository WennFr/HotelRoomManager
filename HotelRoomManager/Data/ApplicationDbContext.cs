using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HotelRoomManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Salutation> Salutation { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<ExtraBed> ExtraBed { get; set; }
        public ApplicationDbContext()
        {
            //En tom konstruktor för migrations
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=localhost;Database=HotelDatabase;Trusted_Connection=True;TrustServerCertificate=true");
            }
        }


    }
}
