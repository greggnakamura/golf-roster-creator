using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        // Tee Time
        public int TeeTimeId { get; set; }  
        public string TeeTime { get; set; }
        public string Golfer1 { get; set; }
        public string Golfer2 { get; set; }
        public string Golfer3 { get; set; }
        public string Golfer4 { get; set; }
        public string Golfer5 { get; set; }
        public string WalkRide1 { get; set; }
        public string WalkRide2 { get; set; }
        public string WalkRide3 { get; set; }
        public string WalkRide4 { get; set; }
        public string WalkRide5 { get; set; }

    }
}