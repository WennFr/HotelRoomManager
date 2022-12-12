using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.Data
{
    public class Salutation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(5)]
        public string SalutationType { get; set; }
        public ICollection<Customer> Customer { get; set; }


    }
}
