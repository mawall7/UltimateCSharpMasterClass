//TicketAggregator App template and commments
//1.AccessDocuments.ReadFromPath(path) 
//2.list<dtos> ticketList = DataReader.GetTicketsFromDocuments(list<string>) 
//2.foreach ticket in ticketList 
//{
//DTOdata ticket (DTOdata)ticket;
//listofdtos.Add(ticket)
//}
//3. litsofdtos.foreach(item => TicketFileWriter.AddText(item.ToString())

//Kan vara enklare om all text för alla pdf filer först läses som en string
//och TicketReadern sedan använder hela texten för samtliga biljetter 
//och returnerar en List<TicketDTO>.  Yield kan ge ett rörigt intryck
//onödig logik som inte hör hemma där enligt kan bryta mot SingleResponsibility Principle.

using System;
using System.IO;
using UglyToad.PdfPig;
using TicketsDataAggregator.Extensions;
using TicketsDataAggregator;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using TicketsDataAggregator.FileAccess;
using TicketsDataAggregator.DataAccess;

namespace DataAccess
{
    public interface Readable
    {
        public string Read(string path);
    }

    public class TicketsDataAggregatorApp
    {
        private string[] _AllPdfFilePaths { get; init; }
        //private List<TicketDataDTO> _TicketData { get; set; } = new List<TicketDataDTO>();
        private string _HandledTextFromData { get; set; }

        private string folderpath = "C:\\Users\\matte\\source\\repos\\UltimateCSharpMasterClass\\aggregatedTickets\\Tickets";
        enum TicketMetaData //still nessecary?
        {
            Title,
            Date,
            Time
        } 
        
        public TicketsDataAggregatorApp(string path)
        {
            _AllPdfFilePaths = Directory.GetFiles(path);
        }

        public void Run()
        {
            try
            {
                foreach (string filepath in _AllPdfFilePaths)
                {
                    
                    PdfFileReader pdfReader = new();
                    string ticketstext = pdfReader.ReadAsString(filepath);
                    
                    TicketsDataReader ticketsReader = new(ticketstext);
                    List<TicketDataDTO> tickets = new();
                    TicketTextWriter writer = new TicketTextWriter(folderpath + "\\aggregatedTickets.txt");
                   
                    foreach (var ticketDto in ticketsReader.YieldReturnsDataDto())
                    {
                        tickets.Add(ticketDto);
                        writer.AddToFile(ticketDto.ToString());
                    }
                }

                     //_TicketData.ForEach(item => Console.WriteLine(item.ToString()));
               
                Console.ReadLine();

            }

            catch (InvalidOperationException e)
            {
                Console.WriteLine("The pdf files could not be opened from the tickets directory. Files may not exist or the wrong path was specified " + e.Message);
            }
            Console.WriteLine("The ticket/tickets were saved successfully to file");
            Console.ReadLine();
        }

    }
}
