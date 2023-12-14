using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDataParser
{
    public class VideoGameModel
    {
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public float Rating { get; set; }

        public override string ToString()
        {
            return $"{Title}, released in {ReleaseYear}, rating: {Rating}" + Environment.NewLine;
        }
    }
}
