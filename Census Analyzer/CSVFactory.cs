using System;
using System.Collections.Generic;
using System.Text;
using static Census_Analyzer.StateCensusAnalyzer;
using static Census_Analyzer.CSVStatesCensus;
using static Census_Analyzer.USCensusData;

namespace Census_Analyzer
{
    public class CSVFactory
    {
        public static StateCensusAnalyzer InstanceOfStateCensusAnalyzer()
        {
            return new StateCensusAnalyzer();
        }
        public static CSVStatesCensus InstanceOfCSVStatesCensus()
        {
            return new CSVStatesCensus();
        }
        public static USCensusData InstanceOfUSCensus()
        {
            return new USCensusData();
        }
        public static GetCSVCount DelegateofStateCensusAnalyse()
        {
            StateCensusAnalyzer csvStateCensus = InstanceOfStateCensusAnalyzer();
            GetCSVCount getCSVCount = new GetCSVCount(StateCensusAnalyzer.numberOfRecords);
            return getCSVCount;
        }
        public static GetCountFromCSVStates DelegateofStatecode()
        {
            CSVStatesCensus statesCodeCSV = InstanceOfCSVStatesCensus();
            GetCountFromCSVStates referToCSVSates = new GetCountFromCSVStates(CSVStatesCensus.getDataFromCSVFile);
            return referToCSVSates;
        }
        public static GetUSCSVCount DelegateofUSCensusData()
        {
            USCensusData csvUSCensus = InstanceOfUSCensus();
            GetUSCSVCount getCSVCount = new GetUSCSVCount(USCensusData.USCensusRecords);
            return getCSVCount;
        }
    }
}