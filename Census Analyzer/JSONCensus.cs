using ChoETL;
using Census_Analyzer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;

namespace Census_Analyser
{
    public class JSONCensus
    {
        /// <summary>
        ///Method for sort First value from json file
        /// </summary>
        public static string SortCSVFileWriteInJsonAndReturnFirstData(string filePath, string jsonFilepath, string sortBy)
        {
            string read = File.ReadAllText(filePath);
            StringBuilder stringBuilder = new StringBuilder();
            using (var loadText = ChoCSVReader.LoadText(read) .WithFirstLineHeader())
            {
                using (var w = new ChoJSONWriter(stringBuilder))w.Write(loadText); 
            }
            File.WriteAllText(jsonFilepath, stringBuilder.ToString());
            JArray arr = CSVOperations.SortJsonBasedOnKey(jsonFilepath, sortBy);
            var jsonArr = JsonConvert.SerializeObject(arr, Formatting.Indented);
            File.WriteAllText(jsonFilepath, jsonArr);

            return CSVOperations.RetriveFirstDataOnKey(jsonFilepath, sortBy);
        }
        /// <summary>
        ///Method for sort last value from json file
        /// </summary>
        public static string SortCSVFileWriteInJsonAndReturnLastData(string filePath, string jsonFilepath, string sortBy)
        {
            string read = File.ReadAllText(filePath);
            StringBuilder stringBuilder = new StringBuilder();
            using (var loadText = ChoCSVReader.LoadText(read).WithFirstLineHeader())
            {
                using (var w = new ChoJSONWriter(stringBuilder))
                    w.Write(loadText);
            }
            File.WriteAllText(jsonFilepath, stringBuilder.ToString());
            JArray arr = CSVOperations.SortJsonBasedOnKey(jsonFilepath, sortBy);
            var jsonArr = JsonConvert.SerializeObject(arr, Formatting.Indented);
            File.WriteAllText(jsonFilepath, jsonArr);

            return CSVOperations.RetriveLastDataOnKey(jsonFilepath, sortBy);
        }
        /// <summary>
        ///sorting the state for population
        /// </summary>
        public static int SortCSVFileWriteInJsonAndReturnNumberOfStatesSorted(string filePath, string jsonFilepath, string sortBy)
        {
            string read = File.ReadAllText(filePath);
            StringBuilder stringBuilder = new StringBuilder();
            using (var loadText = ChoCSVReader.LoadText(read).WithFirstLineHeader())
            {
                using (var w = new ChoJSONWriter(stringBuilder))
                    w.Write(loadText);
            }
            File.WriteAllText(jsonFilepath, stringBuilder.ToString());
            int count = CSVOperations.SortJsonBasedOnKeyAndReturnNumberOfStatesSorted(jsonFilepath, sortBy);
            return count;
        }
        /// <summary>
        ///sorting the state for population,density and area
        /// </summary>
        public static string SortCSVFileOnNumbersAndWriteInJsonAndReturnData(string filePath, string jsonFilepath, string sortBy)
        {
            string read = File.ReadAllText(filePath);
            StringBuilder stringBuilder = new StringBuilder();
            using (var loadText = ChoCSVReader.LoadText(read).WithFirstLineHeader())
            {
                using (var w = new ChoJSONWriter(stringBuilder))
                    w.Write(loadText);
            }
            File.WriteAllText(jsonFilepath, stringBuilder.ToString());
            JArray arr = CSVOperations.SortJsonBasedOnKeyAndValueIsNumber(jsonFilepath, sortBy);
            var jsonArr = JsonConvert.SerializeObject(arr, Formatting.Indented);
            File.WriteAllText(jsonFilepath, jsonArr);

            return CSVOperations.RetriveLastDataOnKey(jsonFilepath, sortBy);
        }
    }
}