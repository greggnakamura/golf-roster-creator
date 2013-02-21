using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Golf_Roster_Creator.ViewModels
{
    public class HomePageViewModel
    {
        // Golf Course
        public int CourseID { get; set; }
        public string Name { get; set; }

        // Golfer
        public string First { get; set; }
        public string Last { get; set; }

    }
}