using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UglyToad.PdfPig;

namespace TicketsDataAggregator.FileAccess
{
    public class PfdFileReader : IReader
    {

        public string Read(string path)
        {
            PdfDocument document = PdfDocument.Open(path);
            return document.GetPage(1).Text;
        }

    }
}
