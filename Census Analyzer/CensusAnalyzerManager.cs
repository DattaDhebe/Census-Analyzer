using System;
using System.Collections.Generic;
using System.IO;

namespace Census_Analyzer
{
    public class CensusAnalyzerManager
    {
        public string filepath;

        /// <summary>
        /// Constructor
        /// </summary>
        public CensusAnalyzerManager(string filepath)
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
        public static int NumberOfRecords(string filepath, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm")
        {
            int count = 0;
            try
            {
                if (Path.GetExtension(filepath) == ".csv")
                {
                    string[] data = File.ReadAllLines(filepath);
                    //check delimiter is correct or incorrect
                    foreach (string str in data)
                    {

                        if (str.Split(delimiter).Length != 4 && str.Split(delimiter).Length != 2)
                        {
                            throw new CensusAnalyzerException("Incorrect Delimiter");
                        }
                    }
                    //checking Incorrect header
                    if (!data[0].Equals(header))
                    {
                        throw new CensusAnalyzerException("Incorrect header");
                    }
                    IEnumerable<string> ele = data;
                    foreach (var elements in ele)
                    {
                        count++;
                    }
                    return count;
                }
                else                                                   //if file type incorrect then throw exception
                {
                    throw new CensusAnalyzerException("File type incorrect");
                }
            }
            catch (FileNotFoundException)                              //if file path incorrect then throw exception
            {
                throw new CensusAnalyzerException("file path incorrect");
            }
            catch (CensusAnalyzerException)
            {
                throw;
            }
        }
    }
}
