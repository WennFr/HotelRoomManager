using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.Data
{
    public class Room
    {
        private RoomType roomType;

        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Floor { get; set; }
        [MaxLength(50)]
        public string Type { get; set; }
        public int Size { get; set; }
        public int ExtraBed { get; set; }
        public List<Booking> RoomBookings { get; set; }

        public enum RoomType
        {
            Single = 1,
            Double = 2

        }
        public enum ExtraBeds
        {
            zero = 0,
            one = 1,
            two = 2,

        }




    }


}
