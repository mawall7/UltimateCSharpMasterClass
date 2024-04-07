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
using System.Text;

namespace DataAccess
{
    public interface Readable
    {
        public string Read(string path);
    }
    
    //Reads each pdf one at a time one pdf can contain more than one tickets
    //converts stringed tickets to DTOs with yield method

    public class TicketsDataAggregatorApp
    {
        private string[] _AllPdfFilePaths { get; set; }
        //private List<TicketDataDTO> _TicketData { get; set; } = new List<TicketDataDTO>();
        private string _HandledTextFromData { get; set; }
        public IReader PdfReader { get; }
        public ITicketsDataReader TicketsReader { get; }
        public ITextWriter Writer { get; }

        public string Path { get; init; }
        public TicketsDataAggregatorApp(IReader pdfReader, ITicketsDataReader ticketsReader, ITextWriter writer, string path)
        {
            PdfReader = pdfReader;
            TicketsReader = ticketsReader;
            Writer = writer;
            Path = path;
        }

        public void Run()
        {
            
            try
            {
                _AllPdfFilePaths = Directory.GetFiles(Path);

                //ToDo strings[] = Reader.Read(filepath) metod som returnerar
                //strings istället för DTOs. Det är onödigt att klassen är beroende av ticketDTO klassen. 
                foreach (string tickets in PdfReader.ReadAsString(Path))
                {

                    //2 alternativ med yield // alternativ 1 med string.Join:
                    var ticketsfromdocument = TicketsReader.SimplerYieldReturnsDataAsString(tickets);
                    Writer.AddToFile(string.Join(Environment.NewLine,ticketsfromdocument));
                    
                    //alternativ 2 med ticketDTO:
                    //foreach (var ticketDto in TicketsReader.SimplerYieldReturnsDataAsDtos(ticketstext))
                    //{
                    //    Writer.AddToFile(ticketDto.ToString());
                    //}
                }
                
                //foreach (string filepath in Directory.GetFiles(Path))
                //{

                //    string ticketstext = PdfReader.ReadAsString(filepath);


                //    foreach (var ticketDto in TicketsReader.SimplerYieldReturnsDataAsDtos(ticketstext))
                //    {
                //        Writer.AddToFile(ticketDto.ToString());
                //    }
                //}


                Console.ReadLine();

            }

            catch (InvalidOperationException e)
            {
                Console.WriteLine("The pdf files could not be opened from the tickets directory. Files may not exist or something unnexpected happened during file processing." + e.Message);
            }
            Console.WriteLine($"The ticket/tickets were saved successfully to file. FilePath: {Path}" );
       
            Console.ReadLine();
        }

    }
}
