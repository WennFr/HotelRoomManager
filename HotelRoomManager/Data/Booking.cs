using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.Data
{
    public class Booking
    {

        [Key]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Customer Customer { get; set; }
        public Room Room { get; set; }



    }
}
