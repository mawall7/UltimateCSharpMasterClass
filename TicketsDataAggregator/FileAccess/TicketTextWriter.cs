using System;
using System.IO;
using TicketsDataAggregator.FileAccess;

namespace DataAccess
{
    internal class TicketTextWriter : ITextWriter
    {
        private string _filenamepath;

        public TicketTextWriter(string filenamepath)
        {
            _filenamepath = filenamepath;
        }

        public void AddToFile(string ticketdata)
        {
            using (StreamWriter writer = File.AppendText(_filenamepath))
            {
                writer.WriteLine(ticketdata);
            }
        }

      
    }
}
