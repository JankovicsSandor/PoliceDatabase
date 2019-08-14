using PoliceDatabase.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PoliceDatabase.DataReader
{
    public class ClientDataReader
    {

        public HashSet<Client> ReadClientData(string filePath)
        {
            string line;
            StreamReader clientsData = new StreamReader(filePath);
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

            clientsData.Close();
            return clients;
        }
    }
}
