using System;

namespace Census_Analyzer
{
    public class StateCensusAnalyzer : ICSVBuilder
    {
        public string filepath;
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
        public delegate int GetCSVCount();
        CSVBuilder csvBuilder = new CSVBuilder();

        public static GetCSVCount numberOfRecords { get; internal set; }

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