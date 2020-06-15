namespace Census_Analyzer
{
    using System;

    [Serializable]
    public class CensusAnalyzerException : Exception
    {
        public CensusAnalyzerException()
        {
        }

        public enum ExceptionType
        {
            Empty_File, File_Not_Found,
            File_Type_Incorrect, Header_Incorrect,
            Wrong_Delimeter, Invalid_Census_Data
        }
        public ExceptionType Type { get; set; }

        public CensusAnalyzerException(ExceptionType Type, string message) : base(message)
        {
            this.Type = Type;
        }

        public CensusAnalyzerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}