﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteFinder
{
    public class QuoteDataFetcher : IQuoteDataFetcher
    {
        private IQuotesApiDataReader _quotesApiDataReader;
        public QuoteDataFetcher(IQuotesApiDataReader quotesApiDataReader)
        {
            _quotesApiDataReader = quotesApiDataReader;
        }

        public async Task<IEnumerable<string>> FetchDataFromAllPagesAsync(int numberOfPages, int quotesPerPage)
        {
            var tasks = new List<Task<string>>();

            for (int i = 0; i < numberOfPages; i++)
            {
                var fetchDataTask = _quotesApiDataReader.ReadAsync(i + 1, quotesPerPage);
                tasks.Add(fetchDataTask);
            }
            return await Task.WhenAll(tasks);
        }

        public async Task<IEnumerable<string>> FetchDataFromAllPagesAsyncSlow(int numberOfPages, int quotesPerPage)
        {
            var result = new List<string>();
            for (int i = 0; i < numberOfPages; i++)
            {
                var responseBody = await _quotesApiDataReader.ReadAsync(i + 1, quotesPerPage);
                result.Add(responseBody);
            }

            return result;

        }
    }
}
