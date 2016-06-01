using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiveLogDataAccess.Models
{
    public class Dive
    {

        public int DiveID { get; set; }

        public string Location { get; set; }

        public DateTime Date { get; set; }
    }
}