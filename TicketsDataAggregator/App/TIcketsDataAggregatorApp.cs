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
        public IReader PdfReader { get; }
        public ITicketsDataReader TicketsReader { get; }
        public ITextWriter Writer { get; }

        private string folderpath = "C:\\Users\\matte\\source\\repos\\UltimateCSharpMasterClass\\aggregatedTickets\\Tickets";
        
        public TicketsDataAggregatorApp(IReader pdfReader, ITicketsDataReader ticketsReader, ITextWriter writer, string path)
        {
            _AllPdfFilePaths = Directory.GetFiles(path);
            PdfReader = pdfReader;
            TicketsReader = ticketsReader;
            Writer = writer;
        }

        public void Run()
        {
            List<TicketDataDTO> tickets = new List<TicketDataDTO>();
            
            try
            {
                foreach (string filepath in _AllPdfFilePaths) 
                {

                    //Read each pdf one at a time one pdf can contain more than one tickets
                    string ticketstext = PdfReader.ReadAsString(filepath);
                    //One or more tickets from one pdf converted to string format
                    //convert stringed tickets to DTOs with yield method

                    //alternativ är List<TicketDTO> tickets = TicketReader.ReturnTicketsFromString(string rawstringtickets)
                    foreach (var ticketDto in TicketsReader.YieldReturnsDataAsDtos(ticketstext))
                    {
                        //tickets.Add(ticketDto); 
                        Writer.AddToFile(ticketDto.ToString());
                    }
                }

                     //_TicketData.ForEach(item => Console.WriteLine(item.ToString()));
               
                Console.ReadLine();

            }

            catch (InvalidOperationException e)
            {
                Console.WriteLine("The pdf files could not be opened from the tickets directory. Files may not exist or something unnexpected happened during file processing." + e.Message);
            }
            Console.WriteLine("The ticket/tickets were saved successfully to file.");
       
            Console.ReadLine();
        }

    }
}
