using System;
using System.IO;

namespace DataAccess
{
    internal class TicketTextWriter
    {
        private string _filenamepath;

        public TicketTextWriter(string filenamepath)
        {
            _filenamepath = filenamepath;
        }

        internal void AddToFile(string ticketdata)
        {
            using (StreamWriter writer = File.AppendText(_filenamepath))
            {
                writer.WriteLine(ticketdata);
            }
        }
    }
}