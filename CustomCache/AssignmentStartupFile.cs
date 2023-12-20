using System;
using System.Collections.Generic;
using System.Threading;
namespace CustomCache {




public interface IDataDownloader
    {
        string DownloadData(string resourceId);

    }

    public class SlowDataDownloader : IDataDownloader
    {

        private readonly CustomCache<string, string> _cache = new();
            
        public string DownloadData(string resourceId)
        {
            //var casheddata = GenericCash.HasData(resourceId);
            return _cache.TryCacheData(resourceId, DownloadDataWithoutCashing);
        }
        
        private string DownloadDataWithoutCashing(string resourceid)
        {
            //let's imagine this method downloads real data,
            //and it does it slowly

            Thread.Sleep(1000);
            return $"Some data for {resourceid}";

        }
    }
}