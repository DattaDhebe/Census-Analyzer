using System;

namespace Census_Analyzer
{
    public class CensusAnalyzerException : Exception
    {
        public string message;

        public string GetMessage 
        { 
            get => this.message; 
        }

        public CensusAnalyzerException(string message)
        {
            this.message = message;
        }
    }

}
