using System;
using System.IO;
using UglyToad.PdfPig;
using TicketsDataAggregator.Extensions;
using TicketsDataAggregator;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace DataAccess
{
    public interface Readable
    {
        public string Read(string path);
    }

    public class TicketsDataAggregatorApp
    {
        private string[] _AllFilepaths { get; init; }
        private List<TicketDataDTO> _TicketData { get; set; } = new List<TicketDataDTO>();
        private string _HandledTextFromData { get; set; }

        enum TicketMetaData //still nessecary?
        {
            Title,
            Date,
            Time
        } 
        
        public TicketsDataAggregatorApp(string path)
        {
            _AllFilepaths = Directory.GetFiles(path);
            
           
        }

        public void Run()
        {
            try
            {
                foreach (string filenamepath in _AllFilepaths)
                {
                    //app Run template
                    //1.AccessDocuments.ReadFromPath(path) 
                    //2.list<dtos> ticketList = DataReader.GetTicketsFromDocuments(list<string>) 
                    //2.foreach ticket in ticketList 
                    //{
                         //DTOdata ticket (DTOdata)ticket;
                         //listofdtos.Add(ticket)
                    //}
                    //3. litsofdtos.foreach(item => Printer.Print(item.ToString())

                    PdfDocument document = PdfDocument.Open(filenamepath);
                   
                    Console.WriteLine(document.GetPage(1).Text);
                    string text = document.GetPage(1).Text;
                    
                    _HandledTextFromData = text.RemoveSubstring("Thank you for choosing our cinema! Here are yourtickets:");
                    string domainSuffix = _HandledTextFromData.Substring(_HandledTextFromData.LastIndexOf("."));
                    //string cultureformat = domainSuffix.ReturnCultureFormat();
                    _HandledTextFromData = _HandledTextFromData.Remove(_HandledTextFromData.IndexOf("Visit", _HandledTextFromData.Length - _HandledTextFromData.IndexOf("Visit")));
                    string folderpath = "C:\\Users\\matte\\source\\repos\\UltimateCSharpMasterClass\\aggregatedTickets\\Tickets";
                    
                    TicketTextWriter writer = new TicketTextWriter(folderpath + "\\aggregatedTickets.txt");

                    foreach (var ticketDto in YieldReturnsDataDto())
                    {
                        //SaveSubstringToList(ticketDto); //spara direkt istället behöver då inte spara i list 
                        writer.AddToFile(ticketDto.ToString());

                    }
                }


                //_TicketData.ForEach(item => Console.WriteLine(item.ToString()));
               
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
                {"Date",  (HandledTextFromData) => HandledTextFromData.IndexOf("Date") },
                {"Time", (HandledTextFromData)  => HandledTextFromData.IndexOf("Time") }
            };
            
            while (_HandledTextFromData.Length > 0)
            {
              
                TicketDataDTO data = new TicketDataDTO();
                
                int startIndex = 0;
                data.Title = HandleData(startIndex,1, datadictionary).RemoveSubstring("Title:");
              
                
                string date = HandleData(startIndex,2, datadictionary).RemoveSubstring("Date:");
                string time = HandleData(startIndex,0, datadictionary).RemoveSubstring("Time:");
                string timedatedata = date +" "+ time; //= HandleData(startIndex, 2, datadictionary).RemoveSubstring("Date:");
                DateTime dateTime = new DateTime();
                
                DateTime.TryParse(timedatedata, out dateTime);
                data.DateAndTime = dateTime; 
                

                yield return data;
            }
        }
       
        //namnet bör bättre beskriva metoden
        public string HandleData(int startDataIndex, int endDictIndex, Dictionary<string, Func<string, int>> dataDictionary)
        {
            
            int endIndex = dataDictionary.ElementAt(endDictIndex).Value.Invoke(_HandledTextFromData);
            endIndex = endIndex > 1 ? endIndex : _HandledTextFromData.Length; 
            
            string result = _HandledTextFromData.ReturnsSubstringFromIndex(startDataIndex, endIndex);
            _HandledTextFromData = _HandledTextFromData.Remove(startDataIndex, endIndex);
            
            return result;
        }
            

       //obs SOLID first principle flytta till ansvarig klass
        public void SaveSubstringToList(TicketDataDTO ticketdatadto)
        {
            _TicketData.Add(ticketdatadto);
            //TicketDataArray[1] = 
        }

     

    }
}
