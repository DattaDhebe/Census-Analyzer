using System;

namespace Census_Analyzer
{
    public class StateCensusAnalyzer : ICSVBuilder
    {
        public string filepath;
        private static string jsonPathstateCensus;

        /// <summary>
        /// Main Method
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to India state census Analyzer");
            string val = CSVOperations.RetriveFirstDataOnKey(jsonPathstateCensus, "State");
            string lat = CSVOperations.RetriveLastDataOnKey(jsonPathstateCensus, "State");

            Console.WriteLine(val);
            Console.WriteLine(lat);
        }
        /// <summary>
        ///Method to find Number of records in file for state census data
        /// </summary>
        public delegate int GetCSVCount(string filepath, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm");
        public static int numberOfRecords(string filepath, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm")
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


        public string CheckForState(string jsonPathstateCensus, string v1, string v2)
        {
            throw new NotImplementedException();
        }

        int ICSVBuilder.numberOfRecords(string filepath, char delimiter, string header)
        {
            throw new NotImplementedException();
        }

        int ICSVBuilder.getDataFromCSVFile(string statecode, char delimiter, string header)
        {
            throw new NotImplementedException();
        }

        int ICSVBuilder.USCensusRecords(string uscensus)
        {
            throw new NotImplementedException();
        }
    }
}