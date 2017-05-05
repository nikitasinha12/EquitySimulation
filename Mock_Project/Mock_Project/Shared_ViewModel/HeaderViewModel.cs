﻿using Mock_Project.Shared_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_Project.Shared_ViewModel
{
    class HeaderViewModel
    {
        public HeaderModel headerModel { get; set; }

        public HeaderViewModel()
        {
            headerModel = new HeaderModel() { ImageUrl = new Uri(@"Resources\Images\logo.jpg",UriKind.Relative), AppTitle = "Trading Simulation" };
        }
    }
}
