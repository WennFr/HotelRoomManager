using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.Data
{
    public class ExtraBed
    {
        [Key]
        public int Id { get; set; }

        public int AllowedAmountOfExtraBeds{ get; set; }


    }
}
