﻿using System;
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
        [Key]
        public int Id { get; set; }
        [Required]
        public int Floor { get; set; }
        [MaxLength(50)]
        [Required]
        public string Type { get; set; }
        [Required]
        public int Size { get; set; }
        public int? ExtraBed { get; set; }

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
