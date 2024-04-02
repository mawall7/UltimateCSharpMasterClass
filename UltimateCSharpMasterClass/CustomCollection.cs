using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidateNumberEtc
{
    class CustomCollection : IEnumerable
    {
        public string [] Words { get; set; }
        public CustomCollection(string[] words) 
        {
            Words = words;
        }

        public IEnumerator GetEnumerator() //returns a class extending the IEnumerator interface
        {
            return new WordsEnumerator(Words);
        }
    }
    public class Iterableableclass : IEnumerable<int>
    {
        private int[] _ages;

        public Iterableableclass(int[] ages)
        {
            _ages = ages;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new AgesEnumerator(_ages);
        }

        IEnumerator IEnumerable.GetEnumerator() //explicit interface implementation
        {
            return GetEnumerator();
        }
    }

    public class AgesEnumerator : IEnumerator<int>
    {
        private int[] _ages;
        private const int _initialposition = -1;
        private int _currentindex = _initialposition;


        public AgesEnumerator(int[] ages)
        {
            _ages = ages;
        }

        object IEnumerator.Current => Current;
        public int Current
        { 
          get
            {
                try
                {
                  return _ages[_currentindex];
                }

                catch (IndexOutOfRangeException e)
                {
                    throw new IndexOutOfRangeException(
                        $"{nameof(Iterableableclass)}'s array was exceeded"
                        + e.Message);
                }
            }
        }


        public bool MoveNext()
        {
            ++_currentindex;
            return _currentindex > _ages.Length;
        }


        public void Reset()
        {
            _currentindex = -1;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
    public class WordsEnumerator : IEnumerator
    {
        private const int InitialPosition = -1;
        private int _currentposition = InitialPosition;
        private string[] _words;

        public WordsEnumerator(string[] words)
        {
            _words = words;
        }

        public object Current 
        {
            get 
            {
                try
                {
                 return _words[_currentposition];
                }
                catch (IndexOutOfRangeException ex)
                {
                    throw new IndexOutOfRangeException(
                        $"{nameof(CustomCollection)}'s end reached.",
                        ex);
                }
            } 
        } 
        public bool MoveNext()
        {
            ++_currentposition;
            return _currentposition > _words.Length;
        }

        public void Reset()
        {
            _currentposition = InitialPosition;
        }
    }
}
