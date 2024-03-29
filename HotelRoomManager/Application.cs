﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HotelRoomManager.Data;
using HotelRoomManager.Menus;

namespace HotelRoomManager
{
    public class Application
    {
        public void Run()
        {
            Builder.BuildDatabase();
            var dbContext = Builder.InitializeData();
            MenuSelection.GetDbContext(dbContext);
            Menu.MainMenu();
        }

    }
}

