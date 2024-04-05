using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UglyToad.PdfPig;

namespace TicketsDataAggregator.FileAccess
{
    public class PdfFileReader : IReader
    {
        public string ReadAsString(string path)
        {
            
            PdfDocument document = PdfDocument.Open(path) ;
            StringBuilder builder = new StringBuilder();
            
            foreach (var page in document.GetPages())
            {
                builder.Append(page.Text);
            }

            return builder.ToString(); //document.GetPage(1).Text;

         }
    }
}
            


