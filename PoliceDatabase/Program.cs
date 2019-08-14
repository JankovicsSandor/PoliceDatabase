using PoliceDatabase.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace PoliceDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            StreamReader central_copy = new StreamReader(@"./central_data.csv");
            central_copy.ReadLine();
            HashSet<CentralDatabaseCopyItem> centralDataCopy = new HashSet<CentralDatabaseCopyItem>();
            CentralDatabaseCopyItem oneRow;
            while ((line = central_copy.ReadLine()) != null)
            {
                var row = line.Split(';');
                oneRow = new CentralDatabaseCopyItem()
                {
                    PlateNum = row[0],
                    Owner = row[1],
                    CarType = row[2],
                    MarkedAsStolen = row[3].Contains("Nem") ? false : true
                };
                centralDataCopy.Add(oneRow);
            }

            central_copy.Close();
            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
