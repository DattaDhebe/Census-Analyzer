namespace Census_Analyser
{
    using ChoETL;
    using Census_Analyzer;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.IO;
    using System.Text;

    public class JSONCensus
    {
        /// <summary>
        ///Method for sort First value from json file
        /// </summary>
        public static string SortCSVFileWriteInJsonAndReturnFirstData(string filePath, string jsonFilepath, string sortBy)
        {
            LoadCSVData(filePath, jsonFilepath);
            ConvertInJArrayFormat(jsonFilepath, sortBy);
            return CSVOperations.RetriveFirstDataOnKey(jsonFilepath, sortBy);
        }
        /// <summary>
        ///Method for sort last value from json file
        /// </summary>
        public static string SortCSVFileWriteInJsonAndReturnLastData(string filePath, string jsonFilepath, string sortBy)
        {
            LoadCSVData(filePath, jsonFilepath);
            ConvertInJArrayFormat(jsonFilepath, sortBy);
            return CSVOperations.RetriveLastDataOnKey(jsonFilepath, sortBy);
        }
        /// <summary>
        ///sorting the state for population
        /// </summary>
        public static int SortCSVFileWriteInJsonAndReturnNumberOfStatesSorted(string filePath, string jsonFilepath, string sortBy)
        {
            LoadCSVData(filePath, jsonFilepath);
            return CSVOperations.SortJsonBasedOnKeyAndReturnNumberOfStatesSorted(jsonFilepath, sortBy);
        }
        /// <summary>
        ///sorting the state for population, Density and Area
        /// </summary>
        public static string SortCSVFileOnNumbersAndWriteInJsonAndReturnData(string filePath, string jsonFilepath, string sortBy)
        {
            LoadCSVData(filePath, jsonFilepath);
            ConvertInJArrayFormat(jsonFilepath, sortBy); 
            //CSVOperations.SortJsonBasedOnKeyAndValueIsNumber(jsonFilepath, sortBy);
            return CSVOperations.RetriveLastDataOnKey(jsonFilepath, sortBy);
        }

        public static string LoadCSVData(string filePath, string jsonFilePath)
        {
            try
            {
                //Load CSV File Data and Convert it into JSon Format
                string read = File.ReadAllText(filePath);
                StringBuilder stringBuilder = new StringBuilder();
                using (var loadText = ChoCSVReader.LoadText(read).WithFirstLineHeader())
                {
                    using (var w = new ChoJSONWriter(stringBuilder))
                        w.Write(loadText);
                }
                File.WriteAllText(jsonFilePath, stringBuilder.ToString());
                return null;
            }
            catch
            {
                throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.Invalid_Census_Data, "Invalid Census Data");
            }
        }

        public static string ConvertInJArrayFormat(string jsonFilepath, string sortBy)
        {
            try
            {
                //convert json data into JArray Format 
                JArray arr = CSVOperations.SortJsonBasedOnKey(jsonFilepath, sortBy);
                var jsonArray = JsonConvert.SerializeObject(arr, Formatting.Indented);
                File.WriteAllText(jsonFilepath, jsonArray);
                return null;
            }
            catch
            {
                throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.Invalid_Census_Data, "Invalid Census Data");
            }
        }
    }
}