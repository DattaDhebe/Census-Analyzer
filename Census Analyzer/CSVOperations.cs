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
        ///Method to find Number of records in file for state census data
        /// </summary>
        public static int CountRecords(string[] records)
        {
            List<string> list = new List<string>();
            foreach (string str in records)
            {
                list.Add(str);
            }
            return list.Count;
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
            JArray stateCensusrrary = JArray.Parse(jsonFile);
            for (int i = 0; i < stateCensusrrary.Count - 1; i++)
            {
                for (int j = 0; j < stateCensusrrary.Count - i - 1; j++)
                {
                    if (stateCensusrrary[j][key].ToString().CompareTo(stateCensusrrary[j + 1][key].ToString()) > 0)
                    {
                        var tamp = stateCensusrrary[j + 1];
                        stateCensusrrary[j + 1] = stateCensusrrary[j];
                        stateCensusrrary[j] = tamp;
                    }
                }
            }
            return stateCensusrrary;
        }
        public static string RetriveFirstDataOnKey(string jsonPath, string key)
        {
            string jfile = File.ReadAllText(jsonPath);
            JArray jArray = JArray.Parse(jfile);
            string val = jArray[0][key].ToString();
            return val;
        }
        public static string RetriveLastDataOnKey(string jsonPath, string key)
        {
            string jfile = File.ReadAllText(jsonPath);
            JArray jArray = JArray.Parse(jfile);
            string val = jArray[jArray.Count - 1][key].ToString();
            return val;
        }
    }
}