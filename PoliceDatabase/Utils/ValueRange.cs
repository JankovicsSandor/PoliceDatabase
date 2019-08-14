using PoliceDatabase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoliceDatabase.Utils
{
    public static class ValueRange
    {

        public static bool IsInRange(this double number, double min, double max)
        {
            if (number < min || number > max)
            {
                return false;
            }
            return true;
        }
    }
}
