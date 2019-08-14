using PoliceDatabase.DataReader;
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
            PoliceDataReader policeDataReader = new PoliceDataReader();
            ClientDataReader clientDataReader = new ClientDataReader();
            CarWorkLogger logger = new CarWorkLogger("output.txt");
            Dictionary<string, CentralDatabaseCopyItem> centralDataCopy = policeDataReader.ReadPoliceDatabase(@"./central_data.csv");

            HashSet<Client> clients = clientDataReader.ReadClientData(@"./clients.csv");

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
