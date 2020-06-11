using System;

namespace Census_Analyzer
{
    public class StateCodeCensusDAO : ICSVBuilder
    {
        public string statecode;
        public delegate int GetCountFromCSVStates(string path, char delimiter = ',', string header = "SrNo,State,TIN,StateCode");
        /// <summary>
        ///Method to find Number of records in file for StateCode csv file
        /// </summary>
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

        int ICSVBuilder.NumberOfRecords(string filepath, char delimiter, string header)
        {
            throw new NotImplementedException();
        }

        int ICSVBuilder.GetDataFromCSVFile(string statecode, char delimiter, string header)
        {
            throw new NotImplementedException();
        }

        int ICSVBuilder.USCensusRecords(string uscensus)
        {
            throw new NotImplementedException();
        }
    }
}