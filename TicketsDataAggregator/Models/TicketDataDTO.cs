using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsDataAggregator.Extensions;

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

        public static explicit operator TicketDataDTO(List<string> ticketdata)
        {

            
            TicketDataDTO data = new TicketDataDTO();

            data.Title = ticketdata[0].RemoveSubstring("Title:");
            string date = ticketdata[1].RemoveSubstring("Date:");
            string time = ticketdata[2].RemoveSubstring("Time:");

            string timedatedata = date + " " + time;
            DateTime dateTime = new DateTime();

            DateTime.TryParse(timedatedata, out dateTime);
            data.DateAndTime = dateTime;

            return data;
        }


    }
    
    
        

}
