using NUnit.Framework;
using System;
using Census_Analyzer;
using static Census_Analyzer.StateCensusAnalyzer;
using static Census_Analyzer.CSVStatesCensus;

namespace Census_Analyzer
{
    public class Tests
    {
        GetCSVCount csvstatecensus = CSVFactory.DelegateofStateCensusAnalyse();
        GetCountFromCSVStates statesCodeCSV = CSVFactory.DelegateofStatecode();

        public string filepath = @"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCensusData.csv";
        public string statecode = @"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCode.csv";

        /// <summary>
        ///TC-1.1: Test for checking number of Records
        /// </summary>
        [Test]
        public void GiventheStatesCensusCSVfile_WhenAnalyse_ShouldRecordNumberOfRecordmatches()
        {
            int actual = csvstatecensus(filepath);
            Assert.AreEqual(30, actual);
        }
        /// <summary>
        ///TC-1.2:If file incorrect then throw custom exception
        /// </summary>
        [Test]
        public void GivenIncorrectfile_WhenAnalyse_ShouldThrowCensusuAnalyserException()
        {
            var actual = Assert.Throws<CensusAnalyzerException>(() => csvstatecensus(@"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCensus.csv"));
            Assert.AreEqual("file path incorrect", actual.GetMessage);
        }
        /// <summary>
        ///TC-1.3:If file incorrect then throw custom exception
        /// </summary>
        [Test]
        public void GivenIncorrectfileType_WhenAnalyse_ShouldThrowCensusuAnalyserException()
        {
            var incorrectpath = Assert.Throws<CensusAnalyzerException>(() => csvstatecensus(@"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCensusData.txt"));
            Assert.AreEqual("File type incorrect", incorrectpath.GetMessage);
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
            var incorrectHeader = Assert.Throws<CensusAnalyzerException>(() => csvstatecensus(filepath, ',', "Ste,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual("Incorrect header", incorrectHeader.GetMessage);
        }

        /// <summary>
        ///TC-2.1: Test for checking number of Records in statecode csv
        /// </summary>
        [Test]
        public void GivenCSVStateCodeFile_WhenAnalyse_ShouldRecordNumberOfRecordmatcheStateCode()
        {
            int actual = statesCodeCSV(statecode);
            Assert.AreEqual(38, actual);
        }
        /// <summary>
        ///TC-2.2:If file incorrect then throw custom exception for statecode csv
        /// </summary>
        [Test]
        public void GivenIncorrectfile_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            var actual = Assert.Throws<CensusAnalyzerException>(() => statesCodeCSV(@"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\State.csv"));
            Assert.AreEqual("file path incorrect", actual.GetMessage);
        }
        /// <summary>
        ///TC-2.3:If file incorrect then throw custom exception for statecode csv
        /// </summary>
        [Test]
        public void GivenIncorrectfileType_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            var incorrectpath = Assert.Throws<CensusAnalyzerException>(() => statesCodeCSV(@"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCode.txt"));
            Assert.AreEqual("File type incorrect", incorrectpath.GetMessage);
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

    }
}