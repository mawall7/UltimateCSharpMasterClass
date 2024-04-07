using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsDataAggregator.DataAccess
{
    public interface ITicketsDataReader
    {
        //public IEnumerable<TicketDataDTO> YieldReturnsDataAsDtos(string ticketsdata);
        public IEnumerable<TicketDataDTO> SimplerYieldReturnsDataAsDtos(string ticketsdata);
        
    }
}
