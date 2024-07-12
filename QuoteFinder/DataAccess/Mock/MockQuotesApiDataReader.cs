using QuoteFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuoteFinder.DataAccess.Mock
{
    public class MockQuotesApiDataReader : IQuotesApiDataReader
    {
        private readonly Random _random = new Random();

        public void Dispose()
        {
           
        }

        public Task<string> ReadAsync(int page, int quotesPerPage)
        {
            var root = new Root()
            {
                data = GenerateRandomData(quotesPerPage)
            };
            return Task.FromResult(JsonSerializer.Serialize(root));
            
        }

        private List<Datum> GenerateRandomData(int quotesPerPage)
        {
            return Enumerable.Range(0, quotesPerPage).Select(i =>
            new Datum
            {
                quoteText = GenerateRandomQuote(),
                quoteAuthor = "Unknown"
            }).ToList();
            
            
        }

        private string GenerateRandomQuote()
        {
            var length = _random.Next(5, 30);
            var words = Enumerable.Range(0,length).Select(word => GetRandomWord()).ToList();
            words.Add(Words.All[1]); // always add "able" to be able to find a match in a search
            return string.Join(' ', words);
        }
    
        private string GetRandomWord() 
        {
            var index = _random.Next(0, Words.All.Length);
            return Words.All[index];
        }
        
    }
}
