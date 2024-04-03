using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsDataAggregator
{
    public class TicketDataDTO
    {
        public string Title { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }


        public override string ToString()
        {
            return String.Format("{0, -25} {1, -25} {2, -25}", Title,  "|" + Date, "|" + Time);
            
        }

    }
    
    
        

}
