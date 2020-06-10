using ChoETL;
using Census_Analyzer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Census_Analyser
{
    public class JSONCensus
    {
        /// <summary>
        ///Method for sort First value from json file
        /// </summary>
        public static string SortCSVFileWriteInJsonAndReturnFirstData(string filePath, string jsonFilepath, string key)
        {
            string re = File.ReadAllText(filePath);
            StringBuilder sb = new StringBuilder();
            using (var p = ChoCSVReader.LoadText(re)
                .WithFirstLineHeader()
                )
            {
                using (var w = new ChoJSONWriter(sb))
                    w.Write(p);
            }
            File.WriteAllText(jsonFilepath, sb.ToString());
            JArray arr = CSVOperations.SortJsonBasedOnKey(jsonFilepath, key);
            var jsonArr = JsonConvert.SerializeObject(arr, Formatting.Indented);
            File.WriteAllText(jsonFilepath, jsonArr);

            return CSVOperations.RetriveFirstDataOnKey(jsonFilepath, key);
        }
        /// <summary>
        ///Method for sort last value from json file
        /// </summary>
        public static string SortCSVFileWriteInJsonAndReturnLastData(string filePath, string jsonFilepath, string key)
        {
            string re = File.ReadAllText(filePath);
            StringBuilder sb = new StringBuilder();
            using (var p = ChoCSVReader.LoadText(re)
                .WithFirstLineHeader()
                )
            {
                using (var w = new ChoJSONWriter(sb))
                    w.Write(p);
            }
            File.WriteAllText(jsonFilepath, sb.ToString());
            JArray arr = CSVOperations.SortJsonBasedOnKey(jsonFilepath, key);
            var jsonArr = JsonConvert.SerializeObject(arr, Formatting.Indented);
            File.WriteAllText(jsonFilepath, jsonArr);

            return CSVOperations.RetriveLastDataOnKey(jsonFilepath, key);
        }
        /// <summary>
        ///sorting the state for population
        /// </summary>
        public static int SortCSVFileWriteInJsonAndReturnNumberOfStatesSorted(string filePath, string jsonFilepath, string key)
        {
            string re = File.ReadAllText(filePath);
            StringBuilder sb = new StringBuilder();
            using (var p = ChoCSVReader.LoadText(re)
                .WithFirstLineHeader()
                )
            {
                using (var w = new ChoJSONWriter(sb))
                    w.Write(p);
            }
            File.WriteAllText(jsonFilepath, sb.ToString());
            int count = CSVOperations.SortJsonBasedOnKeyAndReturnNumberOfStatesSorted(jsonFilepath, key);
            return count;
        }
        /// <summary>
        ///sorting the state for population,density and area
        /// </summary>
        public static string SortCSVFileOnNumbersAndWriteInJsonAndReturnData(string filePath, string jsonFilepath, string key)
        {
            string re = File.ReadAllText(filePath);
            StringBuilder sb = new StringBuilder();
            using (var p = ChoCSVReader.LoadText(re)
                .WithFirstLineHeader()
                )
            {
                using (var w = new ChoJSONWriter(sb))
                    w.Write(p);
            }
            File.WriteAllText(jsonFilepath, sb.ToString());
            JArray arr = CSVOperations.SortJsonBasedOnKeyAndValueIsNumber(jsonFilepath, key);
            var jsonArr = JsonConvert.SerializeObject(arr, Formatting.Indented);
            File.WriteAllText(jsonFilepath, jsonArr);

            return CSVOperations.RetriveLastDataOnKey(jsonFilepath, key);
        }
    }
}