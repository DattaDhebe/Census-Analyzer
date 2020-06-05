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

        [Test]
        public void GivenCensusCSVFile_ShouldReturnNumberOfRecords()
        {
            DataTable csvData = CensusAnalyzerManager.LoadCensusData(Census_CSV_File_Path);
            Assert.AreEqual(29, csvData.Rows.Count);
        }

        [Test]
        public void GivenEmptyFile_ShouldReturnCustomException()
        {
            try
            {
                DataTable csvData = CensusAnalyzerManager.LoadCensusData("");
            }
            catch (CensusAnalyzerException e)
            {
                Assert.AreEqual(CensusAnalyzerException.ExceptionType.Empty_File, e.eType);
            }
        }


    }
}