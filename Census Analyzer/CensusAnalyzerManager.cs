﻿using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Census_Analyzer
{
    public class CensusAnalyzerManager
    {
        public static DataTable LoadCensusData(string csv_file_path)
        {
            DataTable csvData = new DataTable();

            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        csvData.Columns.Add(datecolumn);
                    }

                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
                return csvData;
            }
            catch (FileNotFoundException)
            {
                throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.File_Not_Found, "");
            }
            catch (ArgumentNullException)
            {
                throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.Empty_File, "");
            }

            
        }
    }
}
