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

        public CashingDataDownloader(IDataDownloader downloader)
        {
            _dataDownloader = downloader;
        }

        public string DownloadData(string resourceId)
        {
            return _cache.GetData(resourceId, _dataDownloader.DownloadData);
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