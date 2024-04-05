using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsDataAggregator.Extensions;

namespace TicketsDataAggregator.DataAccess
{
    class TicketsDataReader : ITicketsDataReader
    {
        private string _HandledRawTextFromData;

        public TicketsDataReader()
        {
           
        }

        private void FormatTicketData()
        {
             _HandledRawTextFromData = _HandledRawTextFromData.RemoveSubstring("Thank you for choosing our cinema! Here are yourtickets:");
             //string domainSuffix = _HandledRawTextFromData.Substring(_HandledRawTextFromData.LastIndexOf("."));
            //string cultureformat = domainSuffix.ReturnCultureFormat();
             _HandledRawTextFromData = _HandledRawTextFromData.Remove(_HandledRawTextFromData.IndexOf("Visit", _HandledRawTextFromData.Length - _HandledRawTextFromData.IndexOf("Visit")));

        }

        public IEnumerable<TicketDataDTO> YieldReturnsDataAsDtos(string ticketData)  //needs parameter? is run until _HandledText is empty.
        {
            _HandledRawTextFromData = ticketData;
            FormatTicketData();
            
            Dictionary<string, Func<string, int>> datadictionary = new Dictionary<string, Func<string, int>>()
            {
                {"Title", (HandledTextFromData) => HandledTextFromData.IndexOf("Title") },
                {"Date",  (HandledTextFromData) => HandledTextFromData.IndexOf("Date") },
                {"Time",  (HandledTextFromData)  => HandledTextFromData.IndexOf("Time") }
            };

            while (_HandledRawTextFromData.Length > 0)  //while all tickets in one file are extracted from pdf
            {

                int startIndex = 0;
                
                TicketDataDTO ticketDTO = new TicketDataDTO();

                //ToDo Refactor like : data.Title = GetData("Title");
                List<string> bufferedticket = new(3);
               
                foreach(var item in datadictionary)
                {
                    string ticketdata = ReturnDataByName(item.Key);
                    bufferedticket.Add(ticketdata);   
                }

                ticketDTO = (TicketDataDTO)bufferedticket;
              
                yield return ticketDTO;

            }
        }

        //Unspecifik name should be more specific like ReturnDataByName(string name //"Title")
        //public string ReturnDataByName(int startDataIndex, int endDictIndex, Dictionary<string, Func<string, int>> dataDictionary)
        //{

        //    int endIndex = dataDictionary.ElementAt(endDictIndex).Value
        //        .Invoke(_HandledRawTextFromData);
        //    endIndex = endIndex > 1 ? endIndex : _HandledRawTextFromData.Length;
            
        //    string result = _HandledRawTextFromData.ReturnsSubstringFromIndex(startDataIndex, endIndex);
        //    _HandledRawTextFromData = _HandledRawTextFromData.Remove(startDataIndex, endIndex);

        //    return result;
        //}

        public string ReturnDataByName(string dataName)
        {
            int startDataIndex = 0;
            string endDataLabel = default;
            
            switch (dataName)
            {
                case "Title": 
                endDataLabel  = "Date";
                break;
                case "Date": 
                endDataLabel = "Time";
                break;
                case "Time":
                endDataLabel ="Title";
                break;
            }
            int endIndex = _HandledRawTextFromData.IndexOf(endDataLabel);
           
            endIndex = endIndex > 1 ? endIndex : _HandledRawTextFromData.Length;

            string result = _HandledRawTextFromData.ReturnsSubstringFromIndex(startDataIndex, endIndex);
            _HandledRawTextFromData = _HandledRawTextFromData.Remove(startDataIndex, endIndex);

            return result;
        }

      


    }
}
