﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QuoteFinder
{
    public class QuotesApiDataReader : IQuotesApiDataReader
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<string> ReadAsync(int page, int quotesPerPage)
        {
            var endpoint = $"https://quote-garden.onrender.com/api/v3/quotes?limit={quotesPerPage}&page={page}";

            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }



}
