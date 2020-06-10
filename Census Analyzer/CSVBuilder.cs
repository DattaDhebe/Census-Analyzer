using System;
using System.Collections.Generic;
using System.Text;

namespace Census_Analyzer
{
    public class CSVBuilder
    {
        public CSVBuilder() { }

        private static string path;
        private static char delimeter;
        private static string header;
        private string[] data;

        public CSVBuilder(string _path, char _delimeter, string _header)
        {
            path = _path;
            delimeter = _delimeter;
            header = _header;
        }

        public string Path
        {
            get
            {
                CSVOperations.CheckFileType(path, ".csv");
                data = CSVOperations.ReadCSVFile(path);
                return path;
            }
        }
        public char Delimeter
        {
            get
            {
                CSVOperations.CheckForDelimiter(data, delimeter);
                return delimeter;
            }
        }
        public string Header
        {
            get
            {
                CSVOperations.CheckForHeader(data, header);
                return header;
            }
        }
        public string[] Records
        {
            get
            {
                return data;
            }
        }
    }
}