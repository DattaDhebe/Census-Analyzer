using System;
using System.Collections.Generic;
using System.Text;

namespace Census_Analyzer
{
    public interface ICSVBuilder
    {
        public int numberOfRecords();
        public int getDataFromCSVFile();
    }
}