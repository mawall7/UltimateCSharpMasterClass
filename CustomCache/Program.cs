﻿using System;

namespace CustomCache
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataDownloader dataDownloader = new CashingDataDownloader(new SlowDataDownloader());

  
            Console.WriteLine(dataDownloader.DownloadData("id1"));
            Console.WriteLine(dataDownloader.DownloadData("id2"));
            Console.WriteLine(dataDownloader.DownloadData("id3"));
            Console.WriteLine(dataDownloader.DownloadData("id1"));
            Console.WriteLine(dataDownloader.DownloadData("id3"));
            Console.WriteLine(dataDownloader.DownloadData("id1"));
            Console.WriteLine(dataDownloader.DownloadData("id2"));
            Console.WriteLine(dataDownloader.DownloadData("id1"));

            Console.ReadKey();
        }
    }
}
