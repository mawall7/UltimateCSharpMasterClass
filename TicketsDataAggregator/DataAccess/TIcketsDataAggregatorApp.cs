using System;
using System.IO;
using UglyToad.PdfPig;
namespace DataAccess
{

    public class TicketsDataAggregatorApp
    {
        private string[] allFilepaths { get; init; }
        public TicketsDataAggregatorApp(string path)
        {
            allFilepaths = Directory.GetFiles(path);
            
            try
            {
                foreach(string filenamepath in allFilepaths)
                {
                    using PdfDocument document = PdfDocument
                        .Open(filenamepath); 
                    
                    Console.WriteLine(document.GetPage(1));
                    Console.WriteLine(document.GetPage(2));
                    Console.WriteLine(document.GetPage(3));
                }
            }

            catch (InvalidOperationException e)
            {
                Console.WriteLine("the pdf files could not be opened from the tickets directory. Files may not exist or the wrong path was specified" + e.Message);
            }

            
            
                    
               
            
            
            Console.ReadLine();
            //throw new NotImplementedException();
        }
        //public string ReadPdf()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
