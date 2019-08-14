using System;
using System.Collections.Generic;
using System.Text;

namespace PoliceDatabase.Models
{
    public class Client
    {
        public string PlateNum { get; set; }
        public string Name { get; set; }
        public string CarType { get; set; }
        public double FrontLeftPressure { get; set; }
        public double FrontRightPressure { get; set; }
        public bool FrontPressureOk
        {
            get
            {
                return FrontLeftPressure < 1.5 || FrontLeftPressure > 3 || FrontRightPressure < 1.5 || FrontRightPressure > 3;
            }
        }
        public double BackLeftPressure { get; set; }
        public double BackRightPressure { get; set; }
        public bool BackPressureOk
        {
            get
            {
                return BackLeftPressure < 1.5 || BackLeftPressure > 3 || BackRightPressure < 1.5 || BackRightPressure > 3;
            }
        }
    }
}
