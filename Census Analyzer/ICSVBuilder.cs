﻿using System;

namespace Census_Analyzer
{
    public interface ICSVBuilder
    {
        public int NumberOfRecords(string filepath, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm");
        public int GetDataFromCSVFile(string statecode, char delimiter = ',', string header = "SrNo,State,TIN,StateCode");
        public int USCensusRecords(string uscensus);
    }
}