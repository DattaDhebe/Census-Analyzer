using NUnit.Framework;
using System;
using static Census_Analyzer.StateCensusAnalyzer;
using static Census_Analyzer.CSVStatesCensus;
using Census_Analyser;
using Newtonsoft.Json.Linq;


namespace Census_Analyzer
{
    public class Tests
    {

        public string filepath = @"C:\Users\Datta\source\repos\Census Analyzer\Census Analyzer Test\IndiaStateCensusData.csv";
        public string statecode = @"C:\Users\Datta\source\repos\Census Analyzer\Census Analyzer Test\IndiaStateCode.csv";
        public string jsonPathstateCensus = @"C:\Users\Datta\source\repos\Census Analyzer\Census Analyzer Test\StateCensusData.JSON";
        public string jsonPathstatecode = @"C:\Users\Datta\source\repos\Census Analyzer\Census Analyzer Test\StateCode.JSON";

        GetCSVCount csvstatecensus = CSVFactory.DelegateofStateCensusAnalyse();
        GetCountFromCSVStates statesCodeCSV = CSVFactory.DelegateofStatecode();

        /// <summary>
        ///TC-1.1: Test for checking number of Records
        /// </summary>
        [Test]
        public void GiventheStatesCensusCSVfile_WhenAnalyse_ShouldRecordNumberOfRecordmatches()
        {
            int actual = CSVOperations.numberOfRecords(filepath);
            Assert.AreEqual(29, actual);
        }
        /// <summary>
        ///TC-1.2:If file incorrect then throw custom exception
        /// </summary>
        [Test]
        public void GivenIncorrectfile_WhenAnalyse_ShouldThrowCensusuAnalyserException()
        {
            var incorrectpath = Assert.Throws<CensusAnalyzerException>(() => csvstatecensus(@"C:\Users\boss\source\repos\CensusAnalyzerProblem\StateCensusData.csv"));
            Assert.AreEqual("file path incorrect", incorrectpath.GetMessage);
        }
        /// <summary>
        ///TC-1.3:If file incorrect then throw custom exception
        /// </summary>
        [Test]
        public void GivenIncorrectfileType_WhenAnalyse_ShouldThrowCensusuAnalyserException()
        {
            var incorrecttype = Assert.Throws<CensusAnalyzerException>(() => csvstatecensus(@"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCensusData.txt"));
            Assert.AreEqual("File type incorrect", incorrecttype.GetMessage);
        }
        /// <summary>
        ///TC-1.4:csv file Correct but delimiter Incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectDelimiter_WhenAnalyse_ShouldThrowCensusAnalyserException()
        {
            var incorrectDelimiter = Assert.Throws<CensusAnalyzerException>(() => csvstatecensus(filepath, '.'));
            Assert.AreEqual("Incorrect Delimiter", incorrectDelimiter.GetMessage);
        }
        /// <summary>
        ///TC-1.5:csv file Correct but header Incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectHeader_WhenAnalyse_ShouldThrowCensusAnalyserException()
        {
            var incorrectHeader = Assert.Throws<CensusAnalyzerException>(() => csvstatecensus(filepath, ',', "St,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual("Incorrect header", incorrectHeader.GetMessage);
        }

        /// <summary>
        ///TC-2.1: Test for checking number of Records in statecode csv
        /// </summary>
        [Test]
        public void GivenCSVStateCodeFile_WhenAnalyse_ShouldRecordNumberOfRecordmatcheStateCode()
        {
            int actual = statesCodeCSV(statecode);
            Assert.AreEqual(37, actual);
        }
        /// <summary>
        ///TC-2.2:If file incorrect then throw custom exception for statecode csv
        /// </summary>
        [Test]
        public void GivenIncorrectfile_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            var incorrectpath = Assert.Throws<CensusAnalyzerException>(() => statesCodeCSV(@"C:\Users\boss\source\repos\CensusAnalyzerProblem\StateCode.csv"));
            Assert.AreEqual("file path incorrect", incorrectpath.GetMessage);
        }
        /// <summary>
        ///TC-2.3:If file incorrect then throw custom exception for statecode csv
        /// </summary>
        [Test]
        public void GivenIncorrectfileType_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            var incorrecttype = Assert.Throws<CensusAnalyzerException>(() => statesCodeCSV(@"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCode.txt"));
            Assert.AreEqual("File type incorrect", incorrecttype.GetMessage);
        }
        /// <summary>
        ///TC-2.4:csv file Correct but delimiter Incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectDelimiter_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            var incorrectDelimiter = Assert.Throws<CensusAnalyzerException>(() => statesCodeCSV(filepath, '.'));
            Assert.AreEqual("Incorrect Delimiter", incorrectDelimiter.GetMessage);
        }
        /// <summary>
        ///TC-2.5:csv file Correct but header Incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectHeader_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            var incorrectHeader = Assert.Throws<CensusAnalyzerException>(() => statesCodeCSV(filepath, ',', "SrN,State,TIN,StateCode"));
            Assert.AreEqual("Incorrect header", incorrectHeader.GetMessage);
        }
        /// <summary>
        ///UC-3 : Givens the first state of the CSV and json path to add into j son after sorting when analyse return.
        /// </summary>
        [Test]
        public void GivenCSVAndJsonPathToAddIntoJSon_AfterSorting_WhenAnalyse_ReturnFirstandLastState()
        {
            string firstValue = JSONCensus.SortCSVFileWriteInJsonAndReturnFirstData(filepath, jsonPathstateCensus, "State");
            Assert.AreEqual("Andhra Pradesh", firstValue);
            string lastValue = JSONCensus.SortCSVFileWriteInJsonAndReturnLastData(filepath, jsonPathstateCensus, "State");
            Assert.AreEqual("West Bengal", lastValue);
        }
        /// <summary>
        /// UC-4 :Givens the state of the CSV and json path to add into j son after sorting when analyse returnlast
        /// </summary>
        [Test]
        public void GivenCSVStateCodeAndJsonPathToAddIntoJSon_AfterSorting_WhenAnalyse_ReturnFirstandLastState()
        {
            string firstValue = JSONCensus.SortCSVFileWriteInJsonAndReturnFirstData(statecode, jsonPathstatecode, "StateCode");
            Assert.AreEqual("AD", firstValue);
            string lastValue = JSONCensus.SortCSVFileWriteInJsonAndReturnLastData(statecode, jsonPathstatecode, "StateCode");
            Assert.AreEqual("WB", lastValue);
        }
        /// <summary>
        /// UC-5 :Given the CSV state census and json to sort from most populous to least when analyse return the number of states sorted.
        /// </summary>
        [Test]
        public void GivenCsvStateCensusAndJson_ToSortFromMostPopulousToLeast_WhenAnalyse_ReturnTheNumberOfSatetesSorted()
        {
            int count = JSONCensus.SortCSVFileWriteInJsonAndReturnNumberOfStatesSorted(filepath, jsonPathstateCensus, "Population");
            Assert.NotZero(count);
        }

        /// <summary>
        /// UC-6 :Givens the state of the CSV and json path to add into json after sorting on density when analyse returnlast.
        /// </summary> 
        [Test]
        public void GivenCSVAndJsonPathToAddIntoJSon_AfterSortingOnDensity_WhenAnalyse_ReturnlastState()
        {
            string lastValue = JSONCensus.SortCSVFileWriteInJsonAndReturnLastData(filepath, jsonPathstateCensus, "DensityPerSqKm");
            Assert.AreEqual("86", lastValue);
        }

    }
}