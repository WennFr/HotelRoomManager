using HotelRoomManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.Controllers
{
    public class Create
    {
        public ApplicationDbContext dbContext { get; set; }
        public Create(ApplicationDbContext context)
        {
            dbContext = context;
        }




    }
}
