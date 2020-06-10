using System;
using System.Collections.Generic;
using System.Text;

namespace Census_Analyzer
{
    public class USCensusData
    {
        public delegate int GetUSCSVCount(string filepath, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm");
        public static int USCensusRecords(string filepath, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm")
        {
            try
            {
                string[] records = CSVOperations.ReadCSVFile(filepath);
                int count = CSVOperations.CountRecords(records);
                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}