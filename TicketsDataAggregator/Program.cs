using DataAccess;
using System;
using System.IO;
using TicketsDataAggregator.DataAccess;
using TicketsDataAggregator.FileAccess;

namespace TicketsDataAggregator
{
    class Program
    {
            private static readonly string _folderpath = @"C:\Users\matte\source\repos\UltimateCSharpMasterClass\aggregatedTickets\Tickets\";
            private static readonly string _textfilename = "aggregatedTickets.txt";
       
        static void Main(string[] args)
        {
            
              try
            {
              
                    TicketsDataAggregatorApp ticketaggregator = 
                        new TicketsDataAggregatorApp(
                        new PdfFileReader(),
                        new TicketsDataReader(),
                        new TicketTextWriter(Path.Combine(_folderpath, _textfilename)),
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
                
