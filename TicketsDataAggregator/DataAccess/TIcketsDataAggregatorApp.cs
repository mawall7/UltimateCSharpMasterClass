using System;
using System.IO;
using UglyToad.PdfPig;
using TicketsDataAggregator.Extensions;
using TicketsDataAggregator;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{

    public class TicketsDataAggregatorApp
    {
        private string[] allFilepaths { get; init; }
        private List<TicketDataDTO> TicketData { get; set; } = new List<TicketDataDTO>();
        private string HandledTextFromData { get; set; }

        enum TicketMetaData
        {
            Title,
            Date,
            Time
        } 
        
        public TicketsDataAggregatorApp(string path)
        {
            allFilepaths = Directory.GetFiles(path);
            
            try
            {
                foreach (string filenamepath in allFilepaths)
                {
                    //to do: dela i två metoder
                    //1 ReadAllDataAsString()
                    PdfDocument document = PdfDocument.Open(filenamepath);

                    Console.WriteLine(document.GetPage(1).Text);
                    string text = document.GetPage(1).Text;
                    //2 SaveDataAsDTOs()
                   
                    HandledTextFromData = text.RemoveSubstring("Thank you for choosing our cinema! Here are yourtickets:");
                    HandledTextFromData = HandledTextFromData.Remove(HandledTextFromData.IndexOf("Visit", HandledTextFromData.Length - HandledTextFromData.IndexOf("Visit")));
                   
                     
                        foreach(var ticketDto in YieldReturnsDataDto())
                        {
                            SaveSubstringToList(ticketDto);
                        
                        }
                        
                    }
                       
                    TicketData.ForEach(item => Console.WriteLine(item.ToString()));
                    //Console.WriteLine("to test removed from title to date:" + HandledTextFromData);
                    Console.ReadLine(); 
                
            }

            catch (InvalidOperationException e)
            {
                Console.WriteLine("the pdf files could not be opened from the tickets directory. Files may not exist or the wrong path was specified" + e.Message);
            }

            Console.ReadLine();
        }

        public IEnumerable<TicketDataDTO> YieldReturnsDataDto()
        {
            Dictionary<string, Func<string, int>> datadictionary = new Dictionary<string, Func<string, int>>()
            {
                {"Title", (HandledTextFromData) => HandledTextFromData.IndexOf("Title") },
                {"Date",  (HandledTextFromData) => HandledTextFromData.IndexOf("Date")},
                {"Time", (HandledTextFromData)  => HandledTextFromData.IndexOf("Time") }
            };
            
            while (HandledTextFromData.Length > 0)
            {
                //int titleIndex = HandledTextFromData.IndexOf("Title:");
                //int dateIndex = HandledTextFromData.IndexOf("Date:");
                //int timeIndex = HandledTextFromData.IndexOf("Time:");
                TicketDataDTO data = new TicketDataDTO();
                
                int startIndex = 0;
                //flytta ut dessa till ny yield ?   
                data.Title = HandleData(startIndex,1, datadictionary);
                data.Date = HandleData(startIndex,2, datadictionary);
                data.Time = HandleData(startIndex,0, datadictionary);
               
                
                yield return data;
            }
        }
       
        public string HandleData(int startDataIndex, int endDictIndex, Dictionary<string, Func<string, int>> dataDictionary)
        {
            
            int endIndex = dataDictionary.ElementAt(endDictIndex).Value.Invoke(HandledTextFromData);
            endIndex = endIndex > 1 ? endIndex : HandledTextFromData.Length; 
            
            string result = HandledTextFromData.ReturnsSubstringFromIndex(startDataIndex, endIndex);
            HandledTextFromData = HandledTextFromData.Remove(startDataIndex, endIndex);
           
            return result;
        }
            

       
        public void SaveSubstringToList(TicketDataDTO ticketdatadto)
        {
            TicketData.Add(ticketdatadto);
            //TicketDataArray[1] = 
        }

    }
}
