using System;
using System.Collections.Generic;
using System.Text;

namespace PoliceDatabase.Models
{
    public class TirePressureChange
    {
        public string Tire { get; set; }
        public double? Amount { get; set; }

        public TirePressureChange(string tire, double? amount)
        {
            this.Tire = tire;
            this.Amount = amount;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (Amount == null)
            {
                sb.Append($"\t{Tire}: Nem igényel munkát");
            }
            else if (Amount > 0)
            {
                sb.Append($"\t{Tire}: +{Amount} bar");
            }
            else if (Amount < 0)
            {
                sb.Append($"\t{Tire}: {Amount} bar");
            }

            return sb.ToString();
        }
    }
}
