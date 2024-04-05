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
        private string _HandledTextFromData;

        public TicketsDataReader()
        {
           
        }

        private void FormatTicketData()
        {
             _HandledTextFromData = _HandledTextFromData.RemoveSubstring("Thank you for choosing our cinema! Here are yourtickets:");
             //string domainSuffix = _HandledTextFromData.Substring(_HandledTextFromData.LastIndexOf("."));
            //string cultureformat = domainSuffix.ReturnCultureFormat();
             _HandledTextFromData = _HandledTextFromData.Remove(_HandledTextFromData.IndexOf("Visit", _HandledTextFromData.Length - _HandledTextFromData.IndexOf("Visit")));

        }

     
        public IEnumerable<TicketDataDTO> YieldReturnsDataAsDtos(string ticketData)  //needs parameter? is run until _HandledText is empty.
        {
            _HandledTextFromData = ticketData;
            FormatTicketData();
            
            Dictionary<string, Func<string, int>> datadictionary = new Dictionary<string, Func<string, int>>()
            {
                {"Title", (HandledTextFromData) => HandledTextFromData.IndexOf("Title") },
                {"Date",  (HandledTextFromData) => HandledTextFromData.IndexOf("Date") },
                {"Time", (HandledTextFromData)  => HandledTextFromData.IndexOf("Time") }
            };

            while (_HandledTextFromData.Length > 0)  //while all tickets in one file are extracted from pdf
            {

                int startIndex = 0;
                TicketDataDTO data = new TicketDataDTO();

                // data.Title = GetData("Title");
                data.Title = ReturnDataByName(startIndex, 1, datadictionary).RemoveSubstring("Title:");
                string date = ReturnDataByName(startIndex, 2, datadictionary).RemoveSubstring("Date:");
                string time = ReturnDataByName(startIndex, 0, datadictionary).RemoveSubstring("Time:");
                string timedatedata = date + " " + time; //= HandleData(startIndex, 2, datadictionary).RemoveSubstring("Date:");
                DateTime dateTime = new DateTime();

                DateTime.TryParse(timedatedata, out dateTime);
                data.DateAndTime = dateTime;


                yield return data;
            }
        }

        //Unspecifik name should be more specific like ReturnDataByName(string name //"Title")
        public string ReturnDataByName(int startDataIndex, int endDictIndex, Dictionary<string, Func<string, int>> dataDictionary)
        {

            int endIndex = dataDictionary.ElementAt(endDictIndex).Value
                .Invoke(_HandledTextFromData);
            endIndex = endIndex > 1 ? endIndex : _HandledTextFromData.Length;
            
            string result = _HandledTextFromData.ReturnsSubstringFromIndex(startDataIndex, endIndex);
            _HandledTextFromData = _HandledTextFromData.Remove(startDataIndex, endIndex);

            return result;
        }


    }
}
