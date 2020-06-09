using System;
using System.Collections.Generic;
using System.IO;

namespace Census_Analyzer
{
    public class CensusAnalyzerManager
    {
        public string filepath;

        public CensusAnalyzerManager(string filepath)
        {
            this.filepath = filepath;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Census Analyzer");
        }

        /// <summary>
        ///Method to find Number of records in file
        /// </summary>
        public static int NumberOfRecords(string filepath, char delimiter = ',', 
                                          string header = "State,Population,AreaInSqKm,DensityPerSqKm")
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
                            throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType
                                                              .Wrong_Delimeter, "Incorrect Delimiter");
                        }
                    }
                    //checking Incorrect header
                    if (!data[0].Equals(header))
                    {
                        throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType
                                                          .Header_Incorrect, "Incorrect header");
                    }
                    IEnumerable<string> ele = data;
                    foreach (var elements in ele)
                    {
                        count++;
                    }
                    return count;
                }
                else //if file type incorrect then throw exception
                {
                    throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType
                                                      .Invalid_Census_Data, "File type incorrect");
                }
            }
            catch (FileNotFoundException) //if file path incorrect then throw exception
            {
                throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType
                                                  .File_Not_Found, "file path incorrect");
            }
            catch (CensusAnalyzerException)
            {
                throw;
            }
        }
    }
}
