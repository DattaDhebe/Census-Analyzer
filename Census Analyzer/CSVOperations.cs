namespace Census_Analyzer
{
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    ///class for csv file operations
    /// </summary>
    public class CSVOperations
    {
        /// <summary>
        ///Method to find Number of records in file for state census data 
        /// </summary>
        public delegate int GetCSVCount(string path);
        public static int NumberOfRecords(string path)
        {
            string[] array = File.ReadAllLines(path);
            return array.Length - 1;
        }
        /// <summary>
        ///Method to find Number of records in file for US Census data using map
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
                throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.File_Not_Found, "file path incorrect");
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
                throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.File_Type_Incorrect, "File type incorrect");
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
                        throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.Wrong_Delimeter, "Incorrect Delimiter");
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
                throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.Header_Incorrect, "Incorrect header");
            }
            catch (CensusAnalyzerException)
            {
                throw;
            }
        }
        /// <summary>
        ///Method for sorting
        /// </summary>
        public static JArray SortJsonBasedOnKey(string jsonPath, string sortBy)
        {
            try
            {
                string jsonFile = File.ReadAllText(jsonPath);
                //parsing a json file
                JArray CensusArrary = JArray.Parse(jsonFile);
                //sorting in alphabatically
                for (int i = 0; i < CensusArrary.Count - 1; i++)
                {
                    for (int j = 0; j < CensusArrary.Count - i - 1; j++)
                    {
                        if (CensusArrary[j][sortBy].ToString().CompareTo(CensusArrary[j + 1][sortBy].ToString()) > 0)
                        {
                            var temp = CensusArrary[j + 1];
                            CensusArrary[j + 1] = CensusArrary[j];
                            CensusArrary[j] = temp;
                        }
                    }
                }
                return CensusArrary;
            }
            catch
            {
                throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.Invalid_Census_Data, "Invalid Census Data");
            }
        }
        /// <summary>
        ///Method for Find first state data from json file and sort alphabatically
        /// </summary>
        public static string RetriveFirstDataOnKey(string jsonPath, string sortBy)
        {
            try
            {
                string jfile = File.ReadAllText(jsonPath);
                JArray jArray = JArray.Parse(jfile);
                //Find First value in file wchich is alphabatically sorted
                string val = jArray[0][sortBy].ToString();
                return val;
            }
            catch
            {
                throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.Invalid_Census_Data, "Invalid Census Data");
            }
        }
        /// <summary>
        ///Method for Find Last test data from json file and sort alphabatically
        /// </summary>
        public static string RetriveLastDataOnKey(string jsonPath, string sortBy)
        {
            try
            {
                string jfile = File.ReadAllText(jsonPath);
                JArray jArray = JArray.Parse(jfile);
                JArray sorted = new JArray(jArray.OrderBy(obj => (string)obj[sortBy]));
                //Find last value in file which is alphabatically sorted
                string val = sorted[sorted.Count - 1][sortBy].ToString();
                return val;
            }
            catch
            {
                throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.Invalid_Census_Data, "Invalid Census Data");
            }
        }
        /// <summary>
        ///method to check population is sorted or not
        /// </summary>
        public static int SortJsonBasedOnKeyAndReturnNumberOfStatesSorted(string jsonPath, string sortBy)
        {
            try
            {
                int count = 0;
                string jsonFile = File.ReadAllText(jsonPath);
                JArray CensusArrary = JArray.Parse(jsonFile);
                for (int i = 0; i < CensusArrary.Count - 1; i++)
                {
                    for (int j = 0; j < CensusArrary.Count - i - 1; j++)
                    {
                        if (CensusArrary[j][sortBy].ToString().CompareTo(CensusArrary[j + 1][sortBy].ToString()) > 0)
                        {
                            var temp = CensusArrary[j + 1];
                            CensusArrary[j + 1] = CensusArrary[j];
                            CensusArrary[j] = temp;
                            count++;
                        }
                    }
                }
                return count;
            }
            catch
            {
                throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.Invalid_Census_Data, "Invalid Census Data");
            }
        }
        
    }
}