using PoliceDatabase.Models;
using PoliceDatabase.Utils;
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
            StreamReader clientsData = new StreamReader(@"./clients.csv");
            clientsData.ReadLine();
            HashSet<Client> clients = new HashSet<Client>();
            Client clientRow;
            while ((line = clientsData.ReadLine()) != null)
            {
                var row = line.Split(';');
                clientRow = new Client()
                {
                    PlateNum = row[0],
                    Owner = row[1],
                    CarType = row[2],
                    FrontLeftPressure = double.Parse(row[3]),
                    FrontRightPressure = double.Parse(row[4]),
                    BackLeftPressure = double.Parse(row[5]),
                    BackRightPressure = double.Parse(row[6]),

                };
                clients.Add(clientRow);
            }

            central_copy.Close();
            foreach (Client item in clients)
            {
                if (!item.BackPressureOk)
                {
                }

                if (!item.FrontPressureOk)
                {
                }
            }
            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
