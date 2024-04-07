using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsDataAggregator.Extensions;

namespace TicketsDataAggregator.DataAccess
{
    class TicketsDataReader : ITicketsDataReader
    {
       

        //ToDo Use Split with separator array is a much simpler way!
        public IEnumerable<TicketDataDTO> SimplerYieldReturnsDataAsDtos(string ticketData)
        {
            Dictionary<string, CultureInfo> dictionary = new()
            {
                { ".com", new CultureInfo("en-US") },
                { ".fr", new CultureInfo("fr-FR") },
                { ".jp", new CultureInfo("ja-JP") }

            }; 

            var separator = new string[]{ "Title:", "Date:", "Time:", "Visit us" };
            var ticketssplit = ticketData.Split(separator, StringSplitOptions.None);
            for (int i = 1; i < ticketssplit.Count() -1; i = i+3)
            {
                var title = ticketssplit[i];
                var date = ticketssplit[i + 1];
                var time = ticketssplit[i + 2];
                var visitus = ticketssplit.Last();
               
                var languagecode = visitus.Substring(visitus.LastIndexOf("."));
                DateTime dateTime = DateTime.Parse(date + " " + time, dictionary[languagecode], System.Globalization.DateTimeStyles.None);
                
                yield return new TicketDataDTO() { Title = title, DateAndTime = dateTime};
            }
        }

        public IEnumerable<string> SimplerYieldReturnsDataAsString(string ticketData)
        {
            Dictionary<string, CultureInfo> dictionary = new()
            {
                { ".com", new CultureInfo("en-US") },
                { ".fr", new CultureInfo("fr-FR") },
                { ".jp", new CultureInfo("ja-JP") }

            };

            var separator = new string[] { "Title:", "Date:", "Time:", "Visit us" };
            var ticketssplit = ticketData.Split(separator, StringSplitOptions.None);
            for (int i = 1; i < ticketssplit.Count() - 1; i = i + 3)
            {
                var title = ticketssplit[i];
                var date = ticketssplit[i + 1];
                var time = ticketssplit[i + 2];
                var visitus = ticketssplit.Last();

                var languagecode = visitus.Substring(visitus.LastIndexOf("."));
                DateTime dateTime = DateTime.Parse(date + " " + time, dictionary[languagecode], System.Globalization.DateTimeStyles.None);
                var ticketDTO = new TicketDataDTO() { Title = title, DateAndTime = dateTime };
                
                yield return ticketDTO.ToString();
            }
        }


        //public IEnumerable<TicketDataDTO> YieldReturnsDataAsDtos(string ticketData)
        //{
        //    _HandledRawTextFromData = ticketData;
        //    FormatTicketData();

        //    Dictionary<string, Func<string, int>> datadictionary = new Dictionary<string, Func<string, int>>()
        //    {
        //        {"Title", (HandledTextFromData) => HandledTextFromData.IndexOf("Title") },
        //        {"Date",  (HandledTextFromData) => HandledTextFromData.IndexOf("Date") },
        //        {"Time",  (HandledTextFromData)  => HandledTextFromData.IndexOf("Time") }
        //    };

        //    while (_HandledRawTextFromData.Length > 0)  //while all tickets in one file are extracted from pdf
        //    {

        //        TicketDataDTO ticketDTO = new TicketDataDTO();

        //        //* Possible ToDo Refactor like : data.Title = GetData("Title")
        //        List<string> bufferedticket = new(3);

        //        foreach(var item in datadictionary)
        //        {
        //            string ticketdata = ReturnDataByName(item.Key);
        //            bufferedticket.Add(ticketdata);   
        //        }

        //        ticketDTO = (TicketDataDTO)bufferedticket; // * Possible refactor 

        //        yield return ticketDTO;

        //    }
        //}

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

        //public string ReturnDataByName(string dataName)
        //{
        //    int startDataIndex = 0;
        //    string endDataLabel = default;

        //    switch (dataName)
        //    {
        //        case "Title": 
        //        endDataLabel  = "Date";
        //        break;
        //        case "Date": 
        //        endDataLabel = "Time";
        //        break;
        //        case "Time":
        //        endDataLabel ="Title";
        //        break;
        //    }
        //    int endIndex = _HandledRawTextFromData.IndexOf(endDataLabel);

        //    endIndex = endIndex > 1 ? endIndex : _HandledRawTextFromData.Length;

        //    string result = _HandledRawTextFromData.ReturnsSubstringFromIndex(startDataIndex, endIndex);
        //    _HandledRawTextFromData = _HandledRawTextFromData.Remove(startDataIndex, endIndex);

        //    return result;
        //}


    }
}
