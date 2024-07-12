using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteFinder
{
    public interface IQuoteDataFetcher
    {
        Task<IEnumerable<string>> FetchDataFromAllPagesAsync(
            int numberOfPages, int quotesPerPage);
    }
}
