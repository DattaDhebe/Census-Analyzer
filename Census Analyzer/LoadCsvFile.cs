using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyzer
{
    public class LoadCsvFile
    {
        public static int getDataFromCSVFile(string statecode)
        {
            int count = 0;
            string[] data = File.ReadAllLines(statecode);
            IEnumerable<string> ele = data;
            foreach (var elements in data)
            {
                count++;
            }
            return count;
        }
    }


}