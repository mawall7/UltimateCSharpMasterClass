using DataAccess;
using System;
using TicketsDataAggregator.DataAccess;
using TicketsDataAggregator.FileAccess;

namespace TicketsDataAggregator
{
    class Program
    {
            private static string _folderpath = "C:\\Users\\matte\\source\\repos\\UltimateCSharpMasterClass\\aggregatedTickets\\Tickets";
            private static string _textfilename = "\\aggregatedTickets.txt";
        static void Main(string[] args)
        {
            
              try
            {
                //PdfFileReader pdfReader = new PdfFileReader();
                //IReader pdfReader = new PdfFileReader();
                //ITicketsDataReader ticketsReader = new TicketsDataReader(); 

                TicketsDataAggregatorApp ticketaggregator = 
                    new TicketsDataAggregatorApp(
                    new PdfFileReader(),
                    new TicketsDataReader(),
                    new TicketTextWriter(_folderpath + _textfilename),
                    _folderpath);
                ticketaggregator.Run();
            }

            catch (Exception e)
            {
                Console.WriteLine("Execution of TicketsDataAggregatorApplication failed because of an Exception. " +  e.Message);
            }

        }
    }
}
                
