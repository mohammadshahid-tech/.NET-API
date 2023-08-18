using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTutorial.Models
{
    public class student
    {
        public string studentID { get; set; } 
        public string studentName { get; set; }

        public string address { get; set; }
        public string age { get; set; }
        public string contact { get; set; }
    }
}