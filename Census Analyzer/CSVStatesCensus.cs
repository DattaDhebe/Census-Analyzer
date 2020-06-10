using Census_Analyzer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Census_Analyzer
{
    /// <summary>
    ///Method to find Number of records in file for StateCode csv file
    /// </summary>
    public class CSVStatesCensus : ICSVBuilder
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
        int ICSVBuilder.numberOfRecords(string filepath, char delimiter, string header)
        {
            throw new NotImplementedException();
        }

        int ICSVBuilder.getDataFromCSVFile(string statecode, char delimiter, string header)
        {
            throw new NotImplementedException();
        }
    }
}