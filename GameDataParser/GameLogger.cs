using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDataParser
{
    class GameLogger : ILogger
    {
        private readonly GameFileRepository _fileRepository;
        private readonly string _path;
        public GameLogger(GameFileRepository repository, string path)
        {
            _fileRepository = repository;
            _path = path;
            
        }
        public void AddMessage(string message, string stackTrace)
        {
            
            var messagestring = $"[{DateTime.Now}]\nException Message:{message}" +
                $"\nStackTrace:{stackTrace}\n\n";
           
            _fileRepository.Save(messagestring, _path);
            
            
            
            
            

        }
    }
}
