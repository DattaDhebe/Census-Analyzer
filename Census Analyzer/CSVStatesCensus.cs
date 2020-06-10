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
        public delegate int GetCountFromCSVStates();

        CSVBuilder csvBuilder = new CSVBuilder();

        public static GetCountFromCSVStates getDataFromCSVFile { get; internal set; }

        public int ToGetDataFromCSVFile()
        {
            try
            {
                string pa = csvBuilder.Path;
                char del = csvBuilder.Delimeter;
                string header = csvBuilder.Header;

                int count = CSVOperations.CountRecords(csvBuilder.Records);
                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }

        int ICSVBuilder.numberOfRecords()
        {
            throw new NotImplementedException();
        }

        int ICSVBuilder.getDataFromCSVFile()
        {
            throw new NotImplementedException();
        }
    }
}