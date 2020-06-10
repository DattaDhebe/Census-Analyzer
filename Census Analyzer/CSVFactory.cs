using static Census_Analyzer.StateCensusAnalyzer;
using static Census_Analyzer.StateCodeCensusDAO;
using static Census_Analyzer.USCensusDataDAO;

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
        public static USCensusDataDAO InstanceOfUSCensus()
        {
            return new USCensusDataDAO();
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
            USCensusDataDAO csvUSCensus = InstanceOfUSCensus();
            GetUSCSVCount getCSVCount = new GetUSCSVCount(USCensusDataDAO.USCensusRecords);
            return getCSVCount;
        }
    }
}