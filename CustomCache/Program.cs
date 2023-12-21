//Genom Open-Closed Principle kan vi bygga ut SlowDataDownloader klassen genom att lägga till ny klasser istället för att förändra SlowDataDownloaderklassen. (CustomCache.Get kollar att cachen inte redan innehåller data) Varje ny Downloader kör dels sin egen metod dels en annan Downloader metod genom att ta en annan downladerklass instans i sin konstruktor genom Dependency Injection. 
//I Program rad 16 kommer metoden CashingDataDownloader.DownloadData 1. Att gå till CustomCashe GetData som tar någon Downloadmetod (Funct parameter). 2. Klassen i exemplet tar en PrintingDatadownloader och dess konstruktor tar en SlowDataDownloader. Därför kommer först CashingDataDownloaders DataDownload metoden att köras och 2. Genom CustomCash Get metoden (På rad 19 i CustomCache,
//var data = getDataOnFirstTry)) kommer den här klassens Downloader metod köra Get metoden med den här instansens downloader som Funct parameter, vilket är en PrintingDataDownloader instans i exemplet i Program: new CashinDataDownloader(new PrintingDataDownloader(..). PrintingDatadownloaderns Download metod körs som i sin tur tar en instans av SlowDataDownloader, så att den den klassens
//Downloader metod också körs. Alla klassers Downloader metoder kommer alltså att köras genom att vi tar Downloader som en Funt parameter. Där varje Downloader gör något kan vi få en både Cashing och ha Decoratorklasser som bygger ut klassen genom att använda interfacet.  


using System;

namespace CustomCache
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataDownloader dataDownloader = new CashingDataDownloader(new PrintingDataDownloader(new SlowDataDownloader()));

  
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
