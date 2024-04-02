using DataAccess;
using System;

namespace TicketsDataAggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\matte\\source\\repos\\UltimateCSharpMasterClass\\aggregatedTickets\\Tickets";
            TicketsDataAggregatorApp ticketaggregator = new TicketsDataAggregatorApp(path);

        }
    }
}
