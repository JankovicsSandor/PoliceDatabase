using PoliceDatabase.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PoliceDatabase.DataReader
{
    public class PoliceDataReader
    {
        public Dictionary<string, CentralDatabaseCopyItem> ReadPoliceDatabase(string filePath)
        {
            string line;
            StreamReader central_copy = new StreamReader(filePath);
            central_copy.ReadLine();
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

            return centralDataCopy;
        }
    }
}
