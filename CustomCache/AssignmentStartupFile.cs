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
        public GenericCustomCache CustomCashe { get; set; }
        public SlowDataDownloader(GenericCustomCache cash)
        {
            CustomCashe = cash;
        }
        public string DownloadData(string resourceId)
        {
            //var casheddata = GenericCash.HasData(resourceId);
            var getdata = CustomCashe.TryCacheData<string, string>(resourceId, $"Some cashed data for{ resourceId}");
            
            if (getdata is default(string)){ //default means data is not cashed 
                //let's imagine this method downloads real data,
                //and it does it slowly
                Thread.Sleep(1000);
                return $"Some data for {resourceId}";
            }
            else return getdata;
        }
    }
}