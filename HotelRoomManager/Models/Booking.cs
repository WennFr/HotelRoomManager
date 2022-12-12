using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.Models
{
    public class Booking
    {
        public Customer Customer { get; set; }
        public Room Room { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsSpecialRequest { get; set; }
        public int AmountOfExtraBeds  { get; set; }




    }
}
