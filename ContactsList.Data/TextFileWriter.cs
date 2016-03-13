using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsList.Data
{
    public class TextFileWriter
    {
        private static string fileLocation;

        public TextFileWriter(string filePath)
        {
            fileLocation = filePath;
        }

        public void WriteToFile(string lineToWrite)
        {
            using (StreamWriter w = File.AppendText(fileLocation))
            {
                w.WriteLine(lineToWrite);
            }
        }

        public string[] ReturnAllLines()
        {
            return File.ReadAllLines(fileLocation);
        }

        public void DeleteFromFile(string lineToDelete)
        {
            string[] allLines = ReturnAllLines();
            File.WriteAllText(fileLocation, string.Empty);
            foreach (string line in allLines)
            {
                if (!line.Contains(lineToDelete))
                {
                    WriteToFile(line);
                }
            }
        }
    }
}
