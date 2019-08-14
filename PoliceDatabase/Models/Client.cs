using System;
using System.Collections.Generic;
using System.Text;

namespace PoliceDatabase.Models
{
    public class Client
    {
        public string PlateNum { get; set; }
        public string Owner { get; set; }
        public string CarType { get; set; }
        public double FrontLeftPressure { get; set; }
        public double FrontRightPressure { get; set; }
        public double BackLeftPressure { get; set; }
        public double BackRightPressure { get; set; }
    }
}
