using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetUnderTheHoodAssignment.NewSolution
{
    public class RowV2
    {
        private Dictionary<string, int> _intdata;
        private Dictionary<string, decimal> _decdata;
        private Dictionary<string, string> _stringdata;
        private Dictionary<string, bool> _booldata;

        public RowV2(Dictionary<int> intdata, Dictionary<decimal> decdata, Dictionary<string> stringdata, Dictionary<bool> booldata)
        {
            _intdata = intdata;
            _decdata = decdata;
            _stringdata = stringdata;
            _booldata = booldata;
        }

        public object GetAtColumn(string columnName)
        {
            //return _data[columnName];
            switch (columnName) {
                case _intdata[columnName] != null:
                    return _intdata[columnName];
                    break;
               
                case _decdata[columnName] != null:
                    return _decdata[columnName];
                    break;
               
                case _stringdata[columnName] != null:
                    return _stringdata[columnName];
                    break;
                
                case _booldata[columnName] != null:
                    return _booldata[columnName];
                    break;

            }
            
               
            
        }

    }
}
