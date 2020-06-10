using System;

namespace Census_Analyzer
{
    public class USCensusData
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
    }
}