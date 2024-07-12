using System;
using System.Threading.Tasks;

namespace QuoteFinder
{
    public interface IQuotesApiDataReader: IDisposable
    {
        public Task<string> ReadAsync(int page, int quotesPerPage);
        

        
    }
}