using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Firebase.Database.Query;
using System.Threading.Tasks;
using static EVet.Includes.GlobalVariables;
using System.Net;
using System.Reflection;
using Microsoft.Maui.Storage;
using Firebase.Storage;
using System.Reflection.Emit;
using System.Threading.Tasks;
namespace EVet.Models
{
    public class Appointment
    {
        public string Breed { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
      
        //public string Birthday { get; set; }
        public string Gender { get; set; }

        public string Weight { get; set; }
    }
}
