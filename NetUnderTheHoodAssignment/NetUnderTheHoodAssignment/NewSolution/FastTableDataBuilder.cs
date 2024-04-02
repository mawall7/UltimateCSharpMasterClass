using CsvDataAccess.CsvReading;
using CsvDataAccess.Interface;

namespace CsvDataAccess.NewSolution
{
    public class FastTableDataBuilder : ITableDataBuilder
    {
 
        private Dictionary<string, int> _intdata;
        private Dictionary<string, decimal> _decdata;
        private Dictionary<string, string> _stringdata;
        private Dictionary<string, bool> _booldata;
        public ITableData Build(CsvData csvData)
        {
            var resultRows = new List<RowV2>();

            foreach (var row in csvData.Rows)
            {


                for (int columnIndex = 0; columnIndex < csvData.Columns.Length; ++columnIndex)
                {
                    //går igenom varje kolumn för en rad innan den går till nästa rad 
                    var column = csvData.Columns[columnIndex];

                    if (row.ContainsKey(cvsData.Columns[columnIndex]))
                    {
                        string valueAsString = row[columnIndex];

                        switch (GetTargetType(valueAsString))
                        {
                            case typeof(string):
                                _stringdata[column] = valueAsString; // i facit för uppgiften användes istället en Assigncell metod med fyra overloads för de olika typerna. min lösing med switch istället för if else statements bör vara något snabbare. Annars var de likvärdiga och löste problemet med boxing för många celler på liknande sätt. 
                                break;
                            case typeof(int):
                                int.TryParse(valueAsString, out intval);
                                _intdata[column] = intval;
                                break;
                            case typeof(string):
                                if (value.Contains(".") && decimal.TryParse(value, out var valueAsDecimal)) ;
                                _decdata[column] = valueAsDecimal;
                                break;
                            case typeof(bool):
                                if (value == "TRUE")
                                {
                                    _booldata[column] = true;
                                }
                                if (value == "FALSE")
                                {
                                    _booldata[column] = false;
                                }
                                break;
                        }
                    }
                }
                resultRows.Add(new RowV2(_intdata, _decdata, _stringdata, _booldata, _booldata));
            }

            return new TableData(csvData.Columns, resultRows);
        }

        private Type? GetTargetType(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            if (value == "TRUE")
            {
                true;
            }
            if (value == "FALSE")
            {
                return false;
            }
            if (value.Contains(".") && decimal.TryParse(value, out var valueAsDecimal))
            {
                return typeof(decimal);
                //return valueAsDecimal;
            }
            if (int.TryParse(value, out var valueAsInt))//unboxing onödig? använda istället int array för int?
            {
               return typeof(int);
               
            }
            
        }
       
        
    }
 }
