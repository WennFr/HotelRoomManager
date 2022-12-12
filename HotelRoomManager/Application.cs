using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HotelRoomManager.Controllers;
using HotelRoomManager.Data;

namespace HotelRoomManager
{
    public class Application
    {

        public Application()
        {
            
            Builder.BuildDatabase();
            Builder.InitializeData();

        }


        public void Run()
        {
            Menu.MainMenu();
        }

    }
}

