using System;

namespace Census_Analyzer
{
    /// <summary>
    ///Method to find Number of records in file for StateCode csv file
    /// </summary>
    public class CSVStatesCensus : CSVBuilder
    {
        public string statecode;

        /// <summary>
        /// Constructor
        /// </summary>
        public delegate int GetCountFromCSVStates(string path, char delimiter = ',', string header = "SrNo,State,TIN,StateCode");
        public static int getDataFromCSVFile(string statecode, char delimiter = ',', string header = "SrNo,State,TIN,StateCode")
        {
            try
            {
                bool type = CSVOperations.CheckFileType(statecode, ".csv");
                string[] records = CSVOperations.ReadCSVFile(statecode);
                bool delimit = CSVOperations.CheckForDelimiter(records, delimiter);
                bool head = CSVOperations.CheckForHeader(records, header);
                int count = CSVOperations.CountRecords(records);
                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        int CSVBuilder.numberOfRecords(string filepath, char delimiter, string header)
        {
            throw new NotImplementedException();
        }

        int CSVBuilder.getDataFromCSVFile(string statecode, char delimiter, string header)
        {
            throw new NotImplementedException();
        }
    }
}