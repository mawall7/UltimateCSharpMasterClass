using QuoteFinder.DataAccess.Mock;
using QuoteFinder.UserInteraction;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuoteFinder
{
    public class Program
    {
        static void Main(string[] args)
        {
            var userInteractor = new ConsoleUserInteractor();


            try
            {
                Task.Run(async () =>
               {
                   string word = userInteractor.ReadSingleWord(
                    "What word are you looking for?");
                   int numberOfPages = userInteractor.ReadInteger(
                       "How many pages do you want to read?");
                   int quotesPerPage = userInteractor.ReadInteger(
                       "How many quotes per page?");
                   bool shallProcessInParallel = userInteractor.ReadBool(
                       "Shall process pages in parallel?");
                   bool shallUseMockApiReader = userInteractor.ReadBool("Do you want to mock the api?");


                   using var quotesApiDataReader = new QuotesApiDataReader();
                   
                       
                       var quoteDataFetcher = shallUseMockApiReader ? new QuoteDataFetcher(new MockQuotesApiDataReader()) 
                       : new QuoteDataFetcher(quotesApiDataReader);
                       
                       userInteractor.ShowMessage("Fetching data...");
                       IEnumerable<string> data = await quoteDataFetcher.FetchDataFromAllPagesAsync(
                           numberOfPages, quotesPerPage);
                       userInteractor.ShowMessage("Data is ready.");

                       Stopwatch stopwatch = Stopwatch.StartNew();

                       var quoteDataProcessor = new QuoteDataProcessor(userInteractor);
                       await quoteDataProcessor.ProcessAsync(data, word, shallProcessInParallel);
                       stopwatch.Stop();
                       userInteractor.ShowMessage("Processing took: " + stopwatch.ElapsedMilliseconds);
                    


               }).GetAwaiter().GetResult();
                  

            }
            catch(Exception ex)
            {
                userInteractor.ShowMessage("Exception thrown, api may be down" + ex.Message);

            }
            Console.WriteLine("Program is finished");
            Console.ReadKey();

        }
      
    }
}
