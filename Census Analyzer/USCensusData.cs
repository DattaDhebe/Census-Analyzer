using System;
using System.Collections.Generic;
using System.Text;

namespace Census_Analyzer
{
    public class USCensusData
    {
        public delegate int GetUSCSVCount(string uscensus, char delimiter = ',', string header = "StateId,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density");
        public static int USCensusRecords(string uscensus, char delimiter = ',', string header = "StateId,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density")
        {
            try
            {
                bool type = CSVOperations.CheckFileType(uscensus, ".csv");
                string[] records = CSVOperations.ReadCSVFile(uscensus);
                bool delimit = CSVOperations.CheckForDelimiter(records, delimiter);
                bool head = CSVOperations.CheckForHeader(records, header);
                int count = CSVOperations.Records(records);
                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}