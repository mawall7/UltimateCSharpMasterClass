using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

namespace TicketsDataAggregator.FileAccess
{
    public class PdfFileReader : IReader
    {
        public IEnumerable<string> ReadAsString(string path)
        {
            foreach(var pdfdocument in Directory.GetFiles(path, "*.pdf"))
            {
                using PdfDocument document = PdfDocument.Open(pdfdocument);

                Page page = document.GetPage(1);

                yield return page.Text;
            }


            //StringBuilder builder = new StringBuilder();

            //foreach (var page in document.GetPages())
            //{
            //    builder.Append(page.Text);
            //}

            //return builder.ToString(); //document.GetPage(1).Text;

        }
    }
}
            


