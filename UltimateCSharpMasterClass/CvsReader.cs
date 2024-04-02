using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidateNumberEtc
{
    public class CvsReader
    {
        public IEnumerable<TableRow> Read(string filePath)
        {
            var list = new List<TableRow>();
            using var reader = new StreamReader(filePath);
            
            while (!reader.EndOfStream)
            {
                TableRow row = new TableRow(reader.ReadLine().Split(","));
                list.Add(row);
            }
            
            return list;
        }
    }
                   
               

    public class TableRow
    {
        private string[] _row;
        public TableRow(string[] row)
        {
            _row = row;
        }

        public string ReadCell(int row, int cellnumber)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"row:{ String.Join("|", _row)}";
        }
            
    }
}
