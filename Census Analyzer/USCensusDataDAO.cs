using System;

namespace Census_Analyzer
{
    public class USCensusDataDAO : ICSVBuilder
    {
        /// <summary>
        ///Method to find Number of records in file for US Census Data csv file
        /// </summary>
        public delegate int GetUSCSVCount(string uscensus);
        public static int USCensusRecords(string uscensus)
        {
            try
            {
                bool type = CSVOperations.CheckFileType(uscensus, ".csv");
                string[] records = CSVOperations.ReadCSVFile(uscensus);
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

        int ICSVBuilder.USCensusRecords(string uscensus)
        {
            throw new NotImplementedException();
        }
    }
}