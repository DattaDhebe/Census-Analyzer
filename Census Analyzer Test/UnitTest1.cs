using NUnit.Framework;
using static Census_Analyzer.StateCensusAnalyzer;
using static Census_Analyzer.StateCodeCensusDAO;
using Census_Analyser;

namespace Census_Analyzer
{
    public class Tests
    {

        public string Csv_Census_File_Path = @"C:\Users\Datta\source\repos\Census Analyzer\Census Analyzer Test\IndiaStateCensusData.csv";
        public string Csv_StateCode_File_Path = @"C:\Users\Datta\source\repos\Census Analyzer\Census Analyzer Test\IndiaStateCode.csv";
        public string Csv_USCensus_File_Path = @"C:\Users\Datta\source\repos\Census Analyzer\Census Analyzer Test\USCensusData.csv";
        public string StateCensus_Json_File_Path = @"C:\Users\Datta\source\repos\Census Analyzer\Census Analyzer Test\StateCensusData.JSON";
        public string StateCode_Json_File_Path = @"C:\Users\Datta\source\repos\Census Analyzer\Census Analyzer Test\StateCode.JSON";
        public string USCensus_Json_File_Path = @"C:\Users\Datta\source\repos\Census Analyzer\Census Analyzer Test\USCensusData.JSON";

        GetCSVCount csvStateCensus = CSVFactory.DelegateofStateCensusAnalyse();
        GetCountFromCSVStates statesCodeCSV = CSVFactory.DelegateofStatecode();

        /// <summary>
        ///TC1.1:Test for checking number of Records
        /// </summary>
        [Test]
        public void GiventheStatesCensusCSVfile_WhenAnalyse_ShouldRecordNumberOfRecordmatches()
        {
            int actual = CSVOperations.NumberOfRecords(Csv_Census_File_Path);
            Assert.AreEqual(29, actual);
        }
        /// <summary>
        ///TC-1.2:If file incorrect then throw custom exception
        /// </summary>
        [Test]
        public void GivenIncorrectfile_WhenAnalyse_ShouldThrowCensusuAnalyserException()
        {
            try
            {
                Assert.Throws<CensusAnalyzerException>(() => csvStateCensus(@"StateCensusData.csv"));
            }
            catch (CensusAnalyzerException)
            {
                throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.File_Not_Found, "File Path Incorrect");
            }
        }
        /// <summary>
        ///TC-1.3:If file incorrect then throw custom exception
        /// </summary>
        [Test]
        public void GivenIncorrectfileType_WhenAnalyse_ShouldThrowCensusuAnalyserException()
        {
            try
            {
                Assert.Throws<CensusAnalyzerException>(() => csvStateCensus(@"C:\Users\Datta\source\repos\Census Analyzer\Census Analyzer Test\IndiaStateCensusData.txt"));
            }
            catch (CensusAnalyzerException)
            {
                throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.File_Type_Incorrect, "File Type Incorrect");
            }

        }
        /// <summary>
        ///TC-1.4:csv file Correct but delimiter Incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectDelimiter_WhenAnalyse_ShouldThrowCensusAnalyserException()
        {
            try
            {
                Assert.Throws<CensusAnalyzerException>(() => csvStateCensus(Csv_Census_File_Path, '.'));
            }
            catch (CensusAnalyzerException)
            {
                throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.Wrong_Delimeter, "Wrong Delimeter");
            }

        }
        /// <summary>
        ///TC-1.5:csv file Correct but header Incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectHeader_WhenAnalyse_ShouldThrowCensusAnalyserException()
        {
            try
            {
                Assert.Throws<CensusAnalyzerException>(() => csvStateCensus(Csv_Census_File_Path, ',', "St,Population,AreaInSqKm,DensityPerSqKm"));
            }
            catch (CensusAnalyzerException)
            {
                throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.Header_Incorrect, "Header Incorrect");
            }

        }

        /// <summary>
        ///TC-2.1: Test for checking number of Records in statecode csv
        /// </summary>
        [Test]
        public void GivenCSVStateCodeFile_WhenAnalyse_ShouldRecordNumberOfRecordmatcheStateCode()
        {
            int actual = CSVOperations.NumberOfRecords(Csv_StateCode_File_Path);
            Assert.AreEqual(37, actual);
        }
        /// <summary>
        ///TC-2.2:If file incorrect then throw custom exception for statecode csv
        /// </summary>
        [Test]
        public void GivenIncorrectfile_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            try
            {
                Assert.Throws<CensusAnalyzerException>(() => statesCodeCSV(@"StateCode.csv"));
            }
            catch (CensusAnalyzerException)
            {
                throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.File_Not_Found, "File Path Incorrect");
            }
        }
        /// <summary>
        ///TC-2.3:If file incorrect then throw custom exception for statecode csv
        /// </summary>
        [Test]
        public void GivenIncorrectfileType_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            try
            {
                Assert.Throws<CensusAnalyzerException>(() => statesCodeCSV(@"C:\Users\Datta\source\repos\Census Analyzer\Census Analyzer Test\IndiaStateCode.txt"));
            }
            catch (CensusAnalyzerException)
            {
                throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.File_Type_Incorrect, "File Typpe Incorrect");
            }
        }
        /// <summary>
        ///TC-2.4:csv file Correct but delimiter Incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectDelimiter_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            try
            {
                Assert.Throws<CensusAnalyzerException>(() => statesCodeCSV(Csv_Census_File_Path, '.'));
            }
            catch (CensusAnalyzerException)
            {
                throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.Wrong_Delimeter, "Wrong Delimeter");
            }
        }
        /// <summary>
        ///TC-2.5:csv file Correct but header Incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectHeader_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            try
            {
                Assert.Throws<CensusAnalyzerException>(() => statesCodeCSV(Csv_Census_File_Path, ',', "SrN,State,TIN,StateCode"));
            }
            catch (CensusAnalyzerException)
            {
                throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.Header_Incorrect, "Header Incorrect");
            }

        }
        /// <summary>
        ///UC-3 : Givens the CSV and json path to add into json after sorting when analyse return first State.
        /// </summary>
        [Test]
        public void GivenCSVAndJsonPathToAddIntoJSon_AfterSorting_WhenAnalyse_ReturnFirstState()
        {
            string firstState = JSONCensus.SortCSVFileWriteInJsonAndReturnFirstData(Csv_Census_File_Path, StateCensus_Json_File_Path, "State");
            Assert.AreEqual("Andhra Pradesh", firstState);
        }
        /// <summary>
        /// Givens the CSV and json path to add into json after sorting when analyse return Last State.
        /// </summary>
        [Test]
        public void GivenCSVAndJsonPathToAddIntoJSon_AfterSorting_WhenAnalyse_ReturnLastState()
        {
            string lastState = JSONCensus.SortCSVFileWriteInJsonAndReturnLastData(Csv_Census_File_Path, StateCensus_Json_File_Path, "State");
            Assert.AreEqual("West Bengal", lastState);
        }
        /// <summary>
        /// UC-4 : Givens CSV and json path to add into json after sorting should return First StateCode
        /// </summary>
        [Test]
        public void GivenCSVStateCodeAndJsonPathToAddIntoJSon_AfterSorting_WhenAnalyse_ReturnFirstState()
        {
            string firstValue = JSONCensus.SortCSVFileWriteInJsonAndReturnFirstData(Csv_StateCode_File_Path, StateCode_Json_File_Path, "StateCode");
            Assert.AreEqual("AD", firstValue);
        }
        /// <summary>
        /// Givens CSV and json path to add into json after sorting should return Last StateCode
        /// </summary>
        [Test]
        public void GivenCSVStateCodeAndJsonPathToAddIntoJSon_AfterSorting_WhenAnalyse_ReturnLastState()
        {
            string lastValue = JSONCensus.SortCSVFileWriteInJsonAndReturnLastData(Csv_StateCode_File_Path, StateCode_Json_File_Path, "StateCode");
            Assert.AreEqual("WB", lastValue);
        }
        /// <summary>
        /// UC-5 : Given the CSV state census and json to sort from most populous to least when analyse return the number of sorted states.
        /// </summary>
        [Test]
        public void GivenCsvStateCensusAndJson_ToSortFromMostPopulousToLeast_WhenAnalyse_ReturnTheNumberOfSortedStates()
        {
            int count = JSONCensus.SortCSVFileWriteInJsonAndReturnNumberOfStatesSorted(Csv_Census_File_Path, StateCensus_Json_File_Path, "Population");
            Assert.NotZero(count);
        }
        /// <summary>
        /// UC-6 : Givens the state of the CSV and json path to add into json after sorting on density when analyse return last.
        /// </summary> 
        [Test]
        public void GivenCSVAndJsonPathToAddIntoJSon_AfterSortingOnDensity_WhenAnalyse_ReturnlastState()
        {
            string lastValue = JSONCensus.SortCSVFileWriteInJsonAndReturnLastData(Csv_Census_File_Path, StateCensus_Json_File_Path, "DensityPerSqKm");
            Assert.AreEqual("86", lastValue);
        }
        /// <summary>
        /// UC-7 : Givens the state of the CSV and json path to add into json after sorted based on population and density
        /// </summary> 
        [Test]
        public void GivenCSVAndJsonPathToAddIntoJSon_AfterSortingOnArea_WhenAnalyse_ReturnlastState()
        {
            string lastValue = JSONCensus.SortCSVFileOnNumbersAndWriteInJsonAndReturnData(Csv_Census_File_Path, StateCensus_Json_File_Path, "AreaInSqKm");
            Assert.AreEqual("94163", lastValue);
        }
        /// <summary>
        /// UC-9 : Givens the state of the CSV and json path to add into json after sorted based on population using UScensus
        /// </summary> 
        [Test]
        public void GivenCSVAndJsonPathToAddIntoJSon_AfterSortingOnPopulation_WhenAnalyse_ReturnMostPopulationState()
        {
            int count = JSONCensus.SortCSVFileWriteInJsonAndReturnNumberOfStatesSorted(Csv_USCensus_File_Path, USCensus_Json_File_Path, "Population");
            Assert.NotZero(count);
        }
        /// <summary>
        /// UC-10 : the state of the CSV and json path to add into json after sorted based on population and density
        /// </summary> 
        [Test]
        public void GivenCSVAndJsonPathToAddIntoJSon_AfterSortingOnPopulationDensity_WhenAnalyse_ReturnPopulationDensity()
        {
            string PopulationDensity = JSONCensus.SortCSVFileOnNumbersAndWriteInJsonAndReturnData(Csv_USCensus_File_Path, USCensus_Json_File_Path, "Population Density");
            Assert.AreEqual("92.32", PopulationDensity);
        }
        /// <summary>
        /// UC-11 : Given State Census Data After Sorting on Density Area Should Return Population Area
        /// </summary>
        [Test]
        public void GivenCSVAndJsonPathToAddIntoJSon_AfterSortingOnDensityArea_WhenAnalyse_ReturnPopulationArea()
        {
            string Totalarea = JSONCensus.SortCSVFileOnNumbersAndWriteInJsonAndReturnData(Csv_USCensus_File_Path, USCensus_Json_File_Path, "Total area");
            Assert.AreEqual("94326.27", Totalarea);
        }
    }
}
