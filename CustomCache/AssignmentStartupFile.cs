//Se även beskrivning i Program. Genom Funct parametern i Get metoden kan flera metoder med gemensamt interface köras genom CustomCache klassen som kör metoden Download (i det här fallet när data inte cachas). Man kan på det här sättet köra flera implementationer av Downloadklassen. Download i parametern som körs på en instans av PrintDataDownload, kör i sin tur i sin Download metod en Download metod av sin instans av en SlowDataDownloader. Så klassen kan byggas ut genom att använda en klass som wrapper för en annan så att klassen SlowDataDownloader byggs ut genom att lägga till nya beteenden. 

using System;
using System.Collections.Generic;
using System.Threading;
namespace CustomCache {


public interface IDataDownloader
    {
        string DownloadData(string resourceId);

    }

    public class CashingDataDownloader : IDataDownloader
    {
        private readonly IDataDownloader _dataDownloader;
        private readonly CustomCache<string, string> _cache  = new();

        public CashingDataDownloader(IDataDownloader downloader)  //Program  new PrintingDataDownloader(new SowDataDwonloader)
        {
            _dataDownloader = downloader;
        }

        public string DownloadData(string resourceId)
        {
            return _cache.GetData(resourceId, _dataDownloader.DownloadData); //Se även beskrivning i Program. Genom Funct parametern i Get metoden kan flera metoder med gemensamt interface köras genom CustomCache klassen som kör metoden Download (i det här fallet när data inte cachas). Man kan på det här sättet köra flera implementationer av Downloadklassen. Download i parametern som körs på en instans av PrintDataDownload, kör i sin tur i sin Download metod en Download metod av sin instans av en SlowDataDownloader. Så klassen kan byggas ut genom att använda en klass som wrapper för en annan så att klassen SlowDataDownloader byggs ut genom att lägga till nya beteenden. 
        }
    }

    public class PrintingDataDownloader : IDataDownloader
    {
        private readonly IDataDownloader _downloader;

        public PrintingDataDownloader(IDataDownloader downloader)
        {
            _downloader = downloader;
        }
        public string DownloadData(string resourceId)
        {
            var data = _downloader.DownloadData(resourceId);
            Console.WriteLine("data is ready!");
            return data;
        }
    }

    public class SlowDataDownloader : IDataDownloader
    {

        //private readonly CustomCache<string, string> _cache = new();
            
        //public string DownloadData(string resourceId)
        //{
        //    return _cache.GetData(resourceId, DownloadDataWithoutCashing);
        //}
        
        public string DownloadData(string resourceid)
        {
            //let's imagine this method downloads real data,
            //and it does it slowly

            Thread.Sleep(1000);
            return $"Some data for {resourceid}";

        }
    }
}