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
    }
}