using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteFinder
{
    public interface IQuotesApiDataProcessor
    {
        Task ProcessAsync(
            IEnumerable<string> data,
            string word,
            bool shallProcessInParallel);
    }
}
