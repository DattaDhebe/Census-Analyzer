using System;
using System.IO;

namespace Census_Analyzer
{
    public class CensusAnalyzerManager
    {
        public string filepath;
        public char delimiter = ',';
        
        public CensusAnalyzerManager(string filepath)
        {
            this.filepath = filepath;
        }
        public CensusAnalyzerManager(string filepath, char delimiter)
        {
            this.filepath = filepath;
            this.delimiter = delimiter;
        }
       
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to India state census Analyzer");
        }
        public static object Records(string filepath)
        {
            string[] a = File.ReadAllLines(filepath);
            return a.Length;
        }
        /// <summary>
        ///Method to find Number of records in file
        /// </summary>   
        public object NumberOfRecords()
        {
            try
            {
                if (Path.GetExtension(filepath) != ".csv")
                {
                    throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.Invalid_Census_Data, "File format Incorrect");
                }
                if (filepath != @"C:\Users\Datta\source\repos\Census Analyzer\Census Analyzer Test\IndiaStateCensusData.csv")
                {
                    throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.File_Not_Found, "File Not Found");
                }
                string[] data = File.ReadAllLines(filepath);
                if (data[0] != "State,Population,AreaInSqKm,DensityPerSqKm")
                {
                    throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.Header_Incorrect, "Header Incorrect");
                }
                foreach (var element in data)
                {
                    if (!element.Contains(delimiter))
                    {
                        throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.Wrong_Delimeter, "Delimiter Incorrect");
                    }
                }
                return data.Length - 1;
            }
            catch (CensusAnalyzerException e)
            {
                return e.Message;
            }
        }
    }
}
