using System;
using System.Collections.Generic;
using System.Text;
using static Census_Analyzer.StateCensusAnalyzer;
using static Census_Analyzer.StateCodeCensusDAO;
using static Census_Analyzer.USCensusData;

namespace Census_Analyzer
{
    public class CSVFactory
    {
        public static StateCensusAnalyzer InstanceOfStateCensusAnalyzer()
        {
            return new StateCensusAnalyzer();
        }
        public static StateCodeCensusDAO InstanceOfCSVStatesCensus()
        {
            return new StateCodeCensusDAO();
        }
        public static USCensusData InstanceOfUSCensus()
        {
            return new USCensusData();
        }
        /// <summary>
        ///Method to create object for State Census Data
        /// </summary>
        public static GetCSVCount DelegateofStateCensusAnalyse()
        {
            StateCensusAnalyzer csvStateCensus = InstanceOfStateCensusAnalyzer();
            GetCSVCount getCSVCount = new GetCSVCount(StateCensusAnalyzer.numberOfRecords);
            return getCSVCount;
        }
        /// <summary>
        ///Method to create object for State Code csv
        /// </summary>
        public static GetCountFromCSVStates DelegateofStatecode()
        {
            StateCodeCensusDAO statesCodeCSV = InstanceOfCSVStatesCensus();
            GetCountFromCSVStates referToCSVSates = new GetCountFromCSVStates(StateCodeCensusDAO.getDataFromCSVFile);
            return referToCSVSates;
        }
        /// <summary>
        ///Method to create object for US census Data
        /// </summary>
        public static GetUSCSVCount DelegateofUSCensusData()
        {
            USCensusData csvUSCensus = InstanceOfUSCensus();
            GetUSCSVCount getCSVCount = new GetUSCSVCount(USCensusData.USCensusRecords);
            return getCSVCount;
        }
    }
}