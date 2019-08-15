using PoliceDatabase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoliceDatabase.Utils
{
    public class PressureCalculator
    {
        private double leftTirePressure;
        private double rightTirePressure;

        public double LeftTirePressure
        {
            get { return leftTirePressure; }
            set { leftTirePressure = value; }
        }

        public double RightTirePressure
        {
            get { return rightTirePressure; }
            set { rightTirePressure = value; }
        }

        public IList<TirePressureChange> GetTirePressureDiffToAvg(string title)
        {
            int roundDigit = 3;
            IList<TirePressureChange> changes = new List<TirePressureChange>();
            double avg = (this.leftTirePressure + this.rightTirePressure) / 2;
            if (avg < 1.5)
            {
                avg = 1.5;
            }
            if (avg > 3)
            {
                avg = 3;
            }

            changes.Add(new TirePressureChange($"Bal {title}", Math.Round(avg - this.leftTirePressure, roundDigit)));
            changes.Add(new TirePressureChange($"Jobb {title}", Math.Round(avg - this.rightTirePressure, roundDigit)));

            return changes;

        }

    }
}
