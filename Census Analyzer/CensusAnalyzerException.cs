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
            Empty_File
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