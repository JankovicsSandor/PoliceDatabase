using PoliceDatabase.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PoliceDatabase
{
    public class CarWorkLogger
    {
        private FileStream file;
        private StreamWriter streamWriter;

        public CarWorkLogger(string filePath)
        {
            this.file = File.Open(filePath, FileMode.OpenOrCreate);
            this.streamWriter = new StreamWriter(file);
        }

        public void LogClientDetail(Client client)
        {
            streamWriter.WriteLine($"{client.PlateNum}, {client.Name} ");
        }


        public void LogTirePressureChangeWork(IList<TirePressureChange> changes)
        {
            streamWriter.WriteLine("Kerekek Állapota: ");
            foreach (TirePressureChange item in changes)
            {
                streamWriter.WriteLine(item);
            }
        }

        public void LogCarStatus(string status)
        {
            streamWriter.WriteLine($"Autó jogi státusza:");
            streamWriter.WriteLine($"\t{status}");
        }

        public void LogCarStatus(string status, IList<string> problem)
        {
            streamWriter.WriteLine($"Autó jogi státusza:");
            streamWriter.WriteLine($"\t{status}");
            foreach (string item in problem)
            {
                streamWriter.WriteLine($"\t{item}");
            }

        }

        public void EndLogging()
        {
            this.file.Close();
            this.streamWriter.Close();
        }
    }
}
