using DataAccess;
using System;

namespace TicketsDataAggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\matte\\source\\repos\\UltimateCSharpMasterClass\\aggregatedTickets\\Tickets";
           
            try
            {
                TicketsDataAggregatorApp ticketaggregator = new TicketsDataAggregatorApp(path);
                ticketaggregator.Run();
            }

            catch (Exception e)
            {
                Console.WriteLine("Execution of TicketsDataAggregatorApplication failed because of an Exception " +  e.Message);
            }

        }
    }
}
                
