using System;
using System.Runtime.Serialization;


namespace Census_Analyzer
{

    [Serializable]
    public class CensusAnalyzerException : Exception
    {      
        public CensusAnalyzerException()
        {
        }

        public enum ExceptionType
        {
            Empty_File, File_Not_Found,
            Wrong_Delimeter, Invalid_Census_Data,
            Header_Incorrect
        }
        public ExceptionType eType { get; set; }

        public CensusAnalyzerException(ExceptionType eType, string message) : base(message)
        {
            this.eType = eType;
        }

        public CensusAnalyzerException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}