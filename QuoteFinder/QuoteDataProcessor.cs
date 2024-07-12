using QuoteFinder.Models;
using QuoteFinder.UserInteraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuoteFinder
{
    public class QuoteDataProcessor : IQuotesApiDataProcessor
    {
        private readonly IUserInteractor _userInteractor;

        public QuoteDataProcessor(IUserInteractor userInteractor)
        {
            _userInteractor = userInteractor;
        }

        public async Task ProcessAsync(IEnumerable<string> data, string word, bool shallProcessInParallel)
        {
            if (shallProcessInParallel)
            {
                _userInteractor.ShowMessage("Parallel processing started." + Environment.NewLine);

                var tasks = data.Select(
                    page => Task.Run(() => ProcessPage(page, word)));

                await Task.WhenAll(tasks);
            }
            else
            {
                _userInteractor.ShowMessage(
                     "Sequential processing started." + Environment.NewLine);
                foreach (var page in data)
                {
                    ProcessPage(page, word);
                }
            }
        }

        private void ProcessPage(string pageJson, string word)
        {
            var root = JsonSerializer.Deserialize<Root>(pageJson);

            var quoteWithWord = root?.data
                .Where(quote => quote.quoteText.ContainsWord(word))
                .OrderBy(quote => quote.quoteText.Length).FirstOrDefault();


            if (quoteWithWord is not null)
            {
                _userInteractor.ShowMessage(
                    $"{quoteWithWord.quoteText} -- {quoteWithWord.quoteAuthor}");
            }
            else
            {
                _userInteractor.ShowMessage("No quote found on this page.");
            }
            _userInteractor.ShowMessage(string.Empty);
        }

    }
}
