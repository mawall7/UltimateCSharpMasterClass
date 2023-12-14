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
        private readonly GameFileReader _fileRepository;
        private readonly string _path;
        public GameLogger(GameFileReader repository, string path)
        {
            _fileRepository = repository;
            _path = path;
            
        }
        public void AddMessage(string message, string stackTrace)
        {
            var n = Environment.NewLine;
            var messagestring = $"[{DateTime.Now}]{n}Exception Message:{message}" +
                $"{n}StackTrace:{stackTrace}{n+n}";
           
            _fileRepository.Save(messagestring, _path);
            
            
            
            
            

        }
    }
}
