using System;
using System.Collections.Generic;
using System.Text;

namespace Census_Analyzer
{
    public interface ICSVBuilder
    {
        public int numberOfRecords(string filepath, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm");
        public int getDataFromCSVFile(string statecode, char delimiter = ',', string header = "SrNo,State,TIN,StateCode");
    }
}