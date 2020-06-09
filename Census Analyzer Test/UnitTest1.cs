using NUnit.Framework;
using Census_Analyzer;
using System.Data;

namespace Census_Analyzer_Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        public static string Census_CSV_File_Path = @"C:\Users\Datta\source\repos\Census Analyzer\Census Analyzer Test\IndiaStateCensusData.csv";
        public static string Wrong_CSV_File_Path = @"IndiaStateCensusData.csv";
        public static string Wrong_Extension_File_Path = @"C:\Users\Datta\source\repos\Census Analyzer\Census Analyzer Test\IndiaStateCensusData.txt";
        public static string Wrong_Delimeter_File_Path = @"C:\Users\Datta\source\repos\Census Analyzer\Census Analyzer Test\WrongDelimeter.csv";

        /// <summary>
        ///Test for checking number of Records
        /// </summary>
        [Test]
        public void GivenCensusCSVFile_ShouldReturnNumberOfRecords()
        {
            Assert.AreEqual(30, CensusAnalyzerManager.NumberOfRecords(Census_CSV_File_Path));
        }
        /// <summary>
        ///If file incorrect then throw custom exception
        /// </summary>
        [Test]
        public void GivenWrongFilePath_ShouldReturnCustomException()
        {

            CensusAnalyzerManager stateCensus = new CensusAnalyzerManager(Wrong_CSV_File_Path);
            Assert.AreEqual("File Not Found", stateCensus.NumberOfRecords());
        }
        /// <summary>
        ///If file incorrect then throw custom exception
        /// </summary>
        [Test]
        public void GivenStateCensusDataFile_WhenDataImproper_ShouldReturnsException()
        {
            CensusAnalyzerManager stateCensus = new CensusAnalyzerManager(Wrong_Extension_File_Path);
            Assert.AreEqual("File format Incorrect", stateCensus.NumberOfRecords());
        }
        /// <summary>
        ///csv file Correct but delimiter Incorrect
        /// </summary>
        [Test]
        public void GivenStateCensusDataFile_WhenImproperDelimiter_ShouldReturnsException()
        {

            CensusAnalyzerManager stateCensus = new CensusAnalyzerManager(Wrong_Delimeter_File_Path);
            Assert.AreEqual("File Not Found", stateCensus.NumberOfRecords());
        }
        /// <summary>
        ///csv file Correct but delimiter Incorrect
        /// </summary>
        [Test]
        public void GivenStateCensusDataFile_WhenImproperHeader_ShouldReturnsException()
        {
            CensusAnalyzerManager stateCensus = new CensusAnalyzerManager(Wrong_Delimeter_File_Path);
            Assert.AreEqual("File Not Found", stateCensus.NumberOfRecords());
        }
    }

}