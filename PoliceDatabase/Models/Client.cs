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
                double avg = (FrontLeftPressure + FrontRightPressure) / 2;
                return FrontLeftPressure == avg && FrontRightPressure == avg;
            }
        }
        public double BackLeftPressure { get; set; }
        public double BackRightPressure { get; set; }
        public bool BackPressureOk
        {
            get
            {
                double avg = (BackLeftPressure + BackRightPressure) / 2;
                return BackLeftPressure == avg && BackRightPressure == avg;
            }
        }
    }
}
