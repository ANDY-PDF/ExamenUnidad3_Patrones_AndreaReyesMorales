using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLectura
{
    public class Documento
    {
        private string _title;
        private List<string> _lines;
        private Dictionary<int, ISegmentoTexto> _decoratedSegments = new Dictionary<int, ISegmentoTexto>();

        public Documento(string title)
        {
            _title = title;
            _lines = new List<string>();
        }

        public void LoadText(string text)
        {
            _lines = text.Split('\n').ToList();
        }

        public void DisplayDocument()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n{'═',70}");
            Console.WriteLine($" {_title}");
            Console.WriteLine($"{'═',70}\n");
            Console.ResetColor();

            for (int i = 0; i < _lines.Count; i++)
            {
                Console.Write($"{i + 1,3}. ");

                if (_decoratedSegments.ContainsKey(i))
                {
                    _decoratedSegments[i].Display();
                }
                else
                {
                    Console.Write(_lines[i]);
                }
                Console.WriteLine();
            }

            Console.WriteLine($"\n{'═',70}");
        }

        public void ApplyDecorator(int lineNumber, ISegmentoTexto segment)
        {
            if (lineNumber >= 0 && lineNumber < _lines.Count)
            {
                _decoratedSegments[lineNumber] = segment;
            }
        }

        public string GetLine(int lineNumber)
        {
            if (lineNumber >= 0 && lineNumber < _lines.Count)
                return _lines[lineNumber];
            return null;
        }

        public int GetTotalLines() => _lines.Count;

        public List<(int line, string bookmark)> GetBookmarks()
        {
            var bookmarks = new List<(int, string)>();
            foreach (var kvp in _decoratedSegments)
            {
                if (kvp.Value.IsBookmarked)
                {
                    bookmarks.Add((kvp.Key, kvp.Value.BookmarkName));
                }
            }
            return bookmarks;
        }
    }
}

