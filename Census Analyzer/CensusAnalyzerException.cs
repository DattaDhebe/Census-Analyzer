using System;
using System.Runtime.Serialization;


namespace Census_Analyzer
{

    public class CensusAnalyzerException : Exception
    {
        public string message;

        public string GetMessage { get => this.message; }
        //constructor
        public CensusAnalyzerException(string message)
        {
            this.message = message;
        }
    }
}
