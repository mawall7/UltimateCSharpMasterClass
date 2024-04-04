using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsDataAggregator
{
    public class TicketDataDTO
    {
        public string Title { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Date { get => DateAndTime.Date.ToString("d", CultureInfo.InvariantCulture); } 
        public string Time { get => DateAndTime.TimeOfDay.ToString("t", CultureInfo.InvariantCulture); }

        public override string ToString()
        {
            return String.Format("{0, -25} {1, -25} {2, -25}", Title, "|" + Date, "|" + Time);

        }

    }
    
    
        

}
