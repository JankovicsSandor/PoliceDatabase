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
            CarWorkLogger logger = new CarWorkLogger("output.txt");
            Dictionary<string, CentralDatabaseCopyItem> centralDataCopy = new Dictionary<string, CentralDatabaseCopyItem>();
            CentralDatabaseCopyItem oneRow;
            while ((line = central_copy.ReadLine()) != null)
            {
                var row = line.Split(';');
                oneRow = new CentralDatabaseCopyItem()
                {
                    PlateNum = row[0],
                    Owner = row[1],
                    CarType = row[2],
                    CarStatus = row[3]
                };
                centralDataCopy.Add(oneRow.PlateNum, oneRow);
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
                    Name = row[1],
                    CarType = row[2],
                    FrontLeftPressure = double.Parse(row[3]),
                    FrontRightPressure = double.Parse(row[4]),
                    BackLeftPressure = double.Parse(row[5]),
                    BackRightPressure = double.Parse(row[6]),

                };
                clients.Add(clientRow);
            }

            central_copy.Close();

            foreach (Client client in clients)
            {
                IList<TirePressureChange> changes = new List<TirePressureChange>();
                logger.LogClientDetail(client);
                double leftDiff, rightDiff;
                if (!client.BackPressureOk)
                {
                    // leftDiff = client.BackLeftPressure;
                }
                else
                {
                    changes.Add(new TirePressureChange("Bal hátsó", null));
                    changes.Add(new TirePressureChange("Jobb hátsó", null));
                }

                if (!client.FrontPressureOk)
                {
                }
                else
                {
                    changes.Add(new TirePressureChange("Bal első", null));
                    changes.Add(new TirePressureChange("Jobb első", null));
                }

                logger.LogTirePressureChangeWork(changes);

                CentralDatabaseCopyItem item;
                if (centralDataCopy.TryGetValue(client.PlateNum, out item))
                {
                    IList<string> problems = new List<string>();
                    if (item.CarStatus == "Nem lopott")
                    {
                        if (item.CarType.ToLower() != client.CarType.ToLower())
                        {
                            problems.Add("Rossz autó márka!");
                        }
                        if (item.Owner.ToLower() != client.Name.ToLower())
                        {
                            problems.Add("Rossz sofőr!");
                        }
                        if (problems.Count == 0)
                        {
                            logger.LogCarStatus(item.CarStatus);
                        }
                        else
                        {
                            logger.LogCarStatus("GYANÚS", problems);
                        }
                    }
                    else
                    {
                        logger.LogCarStatus("RIASZTÁS");
                    }

                }
            }

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
