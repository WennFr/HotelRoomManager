using HotelRoomManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomManager.Controllers
{
    public class Delete
    {
        public ApplicationDbContext dbContext { get; set; }
        public Delete(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void DeleteEntity()
        {
            Menu.DeleteSelectionMenu();
            var selectionMenuLimit = 4;
            var selection = MenuSelection.ValidateSelection(selectionMenuLimit);




        }




    }
}
