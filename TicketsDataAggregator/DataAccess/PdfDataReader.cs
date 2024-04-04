namespace DataAccess
{
    public class PdfDataReader : Readable
    {
        private string _Path { get; }

        public PdfDataReader(string filenamepath)
        {
            _Path = filenamepath;
        }


        public string Read(string path)
        {
            throw new System.NotImplementedException();
        }
    }
}