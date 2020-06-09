using System;
using System.Collections.Generic;
using System.IO;

namespace Census_Analyzer
{
    public class StateCensusAnalyzer
    {
        public string filepath;

        /// <summary>
        /// Constructor
        /// </summary>
        public StateCensusAnalyzer(string filepath)
        {
            this.filepath = filepath;
        }
        /// <summary>
        /// Main Method
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to India state census Analyzer");

        }

        /// <summary>
        ///Method to find Number of records in file for state census data
        /// </summary>
        //public delegate int GetCSVCount(string filepath, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm");
        public static int NumberOfRecords(string filepath, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm")
        {
            try
            {
                bool type = CSVOperations.CheckFileType(filepath, ".csv");
                string[] records = CSVOperations.ReadCSVFile(filepath);
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
    }
}
