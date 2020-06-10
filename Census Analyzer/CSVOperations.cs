using Census_Analyzer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Census_Analyzer
{
    /// <summary>
    ///class for csv file operations
    /// </summary>
    public class CSVOperations
    {
        /// <summary>
        ///Method to find Number of records in file for state census data using map
        /// </summary>
        public delegate int GetCSVCount(string path);
        public static int numberOfRecords(string path)
        {
            string[] array = File.ReadAllLines(path);
            return array.Length - 1;
        }
        /// <summary>
        ///Method to find Number of records in file for state census dataand State code using map
        /// </summary>
        public static int CountRecords(string[] records)
        {
            int k = 1;
            Dictionary<int, Dictionary<string, string>> map = new Dictionary<int, Dictionary<string, string>>();
            string[] key = records[0].Split(',');
            for (int i = 1; i < records.Length; i++)
            {
                string[] value = records[i].Split(',');
                Dictionary<string, string> subMap = new Dictionary<string, string>()
                {
                  { key[0], value[0] },
                  { key[1], value[1] },
                  { key[2], value[2] },
                  { key[3], value[3] },
                };
                map.Add(k, subMap);
                k++;
            }
            return map.Count;
        }
        /// <summary>
        ///Method to find Number of records in file for US Census data using map
        /// </summary>
        public static int Records(string[] records)
        {
            int k = 1;
            Dictionary<int, Dictionary<string, string>> map = new Dictionary<int, Dictionary<string, string>>();
            string[] key = records[0].Split(',');
            for (int i = 1; i < records.Length; i++)
            {
                string[] value = records[i].Split(',');
                Dictionary<string, string> subMap = new Dictionary<string, string>()
                {
                  { key[0], value[0] },
                  { key[1], value[1] },
                  { key[2], value[2] },
                  { key[3], value[3] },
                  { key[4], value[4] },
                  { key[5], value[5] },
                  { key[6], value[6] },
                  { key[7], value[7] },
                  { key[8], value[8] },
                };
                map.Add(k, subMap);
                k++;
            }
            return map.Count;
        }
        /// <summary>
        ///Method to find file path is correct or incorrect
        /// </summary>
        public static string[] ReadCSVFile(string filepath)
        {
            try
            {
                string[] data = File.ReadAllLines(filepath);
                return data;
            }
            catch (FileNotFoundException)
            {
                throw new CensusAnalyzerException("file path incorrect");
            }
        }

        /// <summary>
        ///Method to find file type is correct or incorrect
        /// </summary>
        public static bool CheckFileType(string filepath, string type)
        {
            try
            {
                if (Path.GetExtension(filepath).Equals(type))
                {
                    return true;
                }
                throw new CensusAnalyzerException("File type incorrect");
            }
            catch (CensusAnalyzerException)
            {
                throw;
            }
        }
        /// <summary>
        ///Method to find file is correct but derimiter incorrect
        /// </summary>
        public static bool CheckForDelimiter(string[] fileData, char delimiter)
        {
            try
            {
                foreach (string str in fileData)
                {
                    if (str.Split(delimiter).Length != 5 && str.Split(delimiter).Length != 4 && str.Split(delimiter).Length != 2)
                    {
                        throw new CensusAnalyzerException("Incorrect Delimiter");
                    }
                }
                return true;
            }
            catch (CensusAnalyzerException)
            {
                throw;
            }
        }
        /// <summary>
        ///Method to find file is correct but header incorrect
        /// </summary>
        public static bool CheckForHeader(string[] fileheader, string header)
        {
            try
            {
                if (fileheader[0].Equals(header))
                {
                    return true;
                }
                throw new CensusAnalyzerException("Incorrect header");
            }
            catch (CensusAnalyzerException)
            {
                throw;
            }
        }
        /// <summary>
        ///Method for sorting
        /// </summary>
        public static JArray SortJsonBasedOnKey(string jsonPath, string key)
        {
            string jsonFile = File.ReadAllText(jsonPath);
            //parsing a json file
            JArray stateCensusrrary = JArray.Parse(jsonFile);
            //sorting in alphabatically
            for (int i = 0; i < stateCensusrrary.Count - 1; i++)
            {
                for (int j = 0; j < stateCensusrrary.Count - i - 1; j++)
                {
                    if (stateCensusrrary[j][key].ToString().CompareTo(stateCensusrrary[j + 1][key].ToString()) > 0)
                    {
                        var temp = stateCensusrrary[j + 1];
                        stateCensusrrary[j + 1] = stateCensusrrary[j];
                        stateCensusrrary[j] = temp;
                    }
                }
            }
            return stateCensusrrary;
        }
        /// <summary>
        ///Method for Find first state data from json file and sort alphabatically
        /// </summary>
        public static string RetriveFirstDataOnKey(string jsonPath, string key)
        {
            string jfile = File.ReadAllText(jsonPath);
            JArray jArray = JArray.Parse(jfile);
            //Find First value in file wchich is alphabatically sorted
            string val = jArray[0][key].ToString();
            return val;
        }
        /// <summary>
        ///Method for Find Last test data from json file and sort alphabatically
        /// </summary>
        public static string RetriveLastDataOnKey(string jsonPath, string key)
        {
            string jfile = File.ReadAllText(jsonPath);
            JArray jArray = JArray.Parse(jfile);
            //Find last value in file which is alphabatically sorted
            string val = jArray[jArray.Count - 1][key].ToString();
            return val;
        }
        /// <summary>
        ///method to check population is sorted or not
        /// </summary>
        public static int SortJsonBasedOnKeyAndReturnNumberOfStatesSorted(string jsonPath, string key)
        {
            int count = 0;
            string jsonFile = File.ReadAllText(jsonPath);
            JArray stateCensusrrary = JArray.Parse(jsonFile);
            for (int i = 0; i < stateCensusrrary.Count - 1; i++)
            {
                for (int j = 0; j < stateCensusrrary.Count - i - 1; j++)
                {
                    if (stateCensusrrary[j][key].ToString().CompareTo(stateCensusrrary[j + 1][key].ToString()) > 0)
                    {
                        var temp = stateCensusrrary[j + 1];
                        stateCensusrrary[j + 1] = stateCensusrrary[j];
                        stateCensusrrary[j] = temp;
                        count++;
                    }
                }
            }
            return count;
        }
        /// <summary>
        ///sorting for state population,Density and area
        /// </summary>
        public static JArray SortJsonBasedOnKeyAndValueIsNumber(string jsonPath, string key)
        {
            string jsonFile = File.ReadAllText(jsonPath);
            JArray stateCensusrrary = JArray.Parse(jsonFile);
            for (int i = 0; i < stateCensusrrary.Count - 1; i++)
            {
                for (int j = 0; j < stateCensusrrary.Count - i - 1; j++)
                {
                    if ((int)stateCensusrrary[j][key] > (int)stateCensusrrary[j + 1][key])
                    {
                        var temp = stateCensusrrary[j + 1];
                        stateCensusrrary[j + 1] = stateCensusrrary[j];
                        stateCensusrrary[j] = temp;
                    }
                }
            }
            return stateCensusrrary;
        }
    }
}