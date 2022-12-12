using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.Data
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; } = null!;
        [MaxLength(50)]
        public string LastName { get; set; } = null!;
        [MaxLength(50)]
        public string? Address { get; set; }
        [MaxLength(30)]
        public string? Phone { get; set; }
        public Salutation Salutation { get; set; }
        public ICollection<Booking> Booking { get; set; }


    }
}
