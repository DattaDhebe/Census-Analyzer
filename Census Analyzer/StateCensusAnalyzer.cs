namespace Census_Analyzer
{
    using System;
    public class StateCensusAnalyzer : ICSVBuilder
    {
        public string filepath;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to India state census Analyzer");
        }
        /// <summary>
        ///Method to find Number of records in file for state census data
        /// </summary>
        public delegate int GetCSVCount(string filepath, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm");
        public static int NumberOfRecords(string filepath, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm")
        {
            try
            {
                bool type = CSVOperations.CheckFileType(filepath, ".csv");
                string[] records = CSVOperations.ReadCSVFile(filepath);
                bool del = CSVOperations.CheckForDelimiter(records, delimiter);
                bool head = CSVOperations.CheckForHeader(records, header);
                int count = CSVOperations.CountRecords(records);
                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        int ICSVBuilder.NumberOfRecords(string filepath, char v1, string v2)
        {
            throw new NotImplementedException();
        }

        int ICSVBuilder.GetDataFromCSVFile(string statecode, char v1, string v2)
        {
            throw new NotImplementedException();
        }

        int ICSVBuilder.USCensusRecords(string uscensus)
        {
            throw new NotImplementedException();
        }
    }
}